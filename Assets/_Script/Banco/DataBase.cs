using System.Collections;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using System.Collections.Generic;
using System;

namespace SQLiter
{
	/// <summary>
	/// Data base. Classe de conexao com o banco de dados
	/// </summary>
	public class DataBase : MonoBehaviour
	{
		public static DataBase Instance = null;
		public bool DebugMode = false;

		/// <summary>
		/// Table name and DB actual file location
		/// </summary>
		private const string SQL_DB_NAME = "seguranca";

		// feel free to change where the DBs are stored
		// this file will show up in the Unity inspector after a few seconds of running it the first time
		private static readonly string SQL_DB_LOCATION = "URI=file:"
		                                                 + Application.dataPath + Path.DirectorySeparatorChar
		                                                 + "Plugins" + Path.DirectorySeparatorChar
		                                                 + "SQLiter" + Path.DirectorySeparatorChar
		                                                 + "Databases" + Path.DirectorySeparatorChar
		                                                 + SQL_DB_NAME + ".db";
		/// <summary>
		/// DB objects
		/// </summary>
		private IDbConnection mConnection = null;
		//Variavel que recebe a conexao com o banco
		private IDbCommand mCommand = null;
		//executar os comandos SQL
		private IDataReader mReader = null;
		//processar os dados vindo do Banco

		void Awake ()	//conceito de singleton
		{
			if (Instance == null) {
				Instance = this;
				Instance.SQLiteInit ();	//inicia o banco, efetuando testes
			}
		}

		public DataBase GetInstance ()
		{			
			return Instance;
		}

		/// <summary>
		/// Basic initialization of SQLite
		/// </summary>
		private void SQLiteInit ()
		{
			Debug.Log ("SQLiter - Opening SQLite Connection");
			mConnection = new SqliteConnection (SQL_DB_LOCATION);
			mCommand = mConnection.CreateCommand ();
			mConnection.Open ();

			// WAL = write ahead logging, very huge speed increase
			mCommand.CommandText = "PRAGMA journal_mode = WAL;";
			mCommand.ExecuteNonQuery ();

			// journal mode = look it up on google, I don't remember
			mCommand.CommandText = "PRAGMA journal_mode";
			mReader = mCommand.ExecuteReader ();
			if (DebugMode && mReader.Read ())
				Debug.Log ("SQLiter - WAL value is: " + mReader.GetString (0));
			mReader.Close ();

			// more speed increases
			mCommand.CommandText = "PRAGMA synchronous = OFF";
			mCommand.ExecuteNonQuery ();

			// and some more
			mCommand.CommandText = "PRAGMA synchronous";
			mReader = mCommand.ExecuteReader ();
			if (DebugMode && mReader.Read ())
				Debug.Log ("SQLiter - synchronous value is: " + mReader.GetInt32 (0));
			mReader.Close ();
		}

		/// <summary>
		/// Clean up everything for SQLite
		/// </summary>
		private void SQLiteClose ()
		{
			if (mReader != null && !mReader.IsClosed)
				mReader.Close ();
			mReader = null;

			if (mCommand != null)
				mCommand.Dispose ();
			mCommand = null;

			if (mConnection != null && mConnection.State != ConnectionState.Closed)
				mConnection.Close ();
			mConnection = null;
		}

		/// <summary>
		/// Basic execute command - open, create command, execute, close
		/// </summary>
		/// <param name="commandText"></param>
		public void ExecuteNonQuery (string commandText)
		{
			mConnection.Open ();
			mCommand.CommandText = commandText;
			mCommand.ExecuteNonQuery ();
			mConnection.Close ();
		}

		public IDataReader ExecuteQuery (string query)
		{
			try {
				mConnection.Open ();
				mCommand.CommandText = query;
				mReader = mCommand.ExecuteReader ();
				return mReader;
			} catch (Exception e) {
				print (e.ToString ());
				return null;
			} finally {
				mReader.Close ();
				mConnection.Close ();
			}
		}

		public IDbConnection GetConnection ()
		{
			Debug.Log ("SQLiter - Opening SQLite Connection");
			mConnection = new SqliteConnection (SQL_DB_LOCATION);
			mConnection.Open ();
			return mConnection;
		}

		/// <summary>
		/// Clean up SQLite Connections, anything else
		/// </summary>
		void OnDestroy ()
		{
			SQLiteClose ();
		}
	}
}