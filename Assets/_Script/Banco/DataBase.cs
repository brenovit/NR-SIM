using UnityEngine;
using System.IO;
using System.Data;
using System;
using Mono.Data.SqliteClient;

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
		private const string SQL_DB_NAME = "seguranca1.db";

		// feel free to change where the DBs are stored
		// this file will show up in the Unity inspector after a few seconds of running it the first time
		private static string SQL_DB_LOCATION = "";
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
				#if UNITY_ANDROID
				//check if file exists in Application.persistentDataPath
					string filepath = Application.persistentDataPath +"Resources" + Path.DirectorySeparatorChar + SQL_DB_NAME;

					if (!File.Exists (filepath) || new System.IO.FileInfo (filepath).Length == 0) {
					// open StreamingAssets directory and load the db ->
				
						WWW loadDb = new WWW ("jar:file://" + Application.dataPath + "!" + Path.DirectorySeparatorChar + "assets" + Path.DirectorySeparatorChar + "Resources" + SQL_DB_NAME);  // this is the path to your StreamingAssets in android
						int i = 0;
						while (!loadDb.isDone) {
							i++;
							if (i >= 10) {
								break;
							}
						}
						File.WriteAllBytes (filepath, loadDb.bytes);
						}
				SQL_DB_LOCATION = "URI=file:" + filepath;
				#else
				SQL_DB_LOCATION = "URI=file:"
				+ Application.dataPath + Path.DirectorySeparatorChar
				+ "Resources" + Path.DirectorySeparatorChar
				+ SQL_DB_NAME;
				#endif			

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
			if (DebugMode)
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
			if (DebugMode)
				Debug.Log ("SQLiter - Connection Openned");
			CreateTables ();
			InsertDatas ();
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

		void CreateTables ()
		{
			//delete table item if exists
			ExecuteNonQuery ("DROP TABLE IF EXISTS item;");
			//creates table item
			ExecuteNonQuery (@"CREATE TABLE item (
			[id] INTEGER PRIMARY KEY AUTOINCREMENT, 
			[nome] VARCHAR(30) UNIQUE);");
			//delete table pergunta if exists
			ExecuteNonQuery ("DROP TABLE IF EXISTS pergunta;");
			//creates table pergunta
			ExecuteNonQuery (@"CREATE TABLE pergunta(
			[id] INTEGER PRIMARY KEY AUTOINCREMENT, 
			[descricao] VARCHAR(100), 
			[explicacao] VARCHAR(150), 
			[nbr] VARCHAR(15), 
			[titulo] VARCHAR(100));");
			//delete table quiz if exists
			ExecuteNonQuery ("DROP TABLE IF EXISTS quiz;");
			//creates table quiz
			ExecuteNonQuery (@"CREATE TABLE quiz(
			[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
			[id_pergunta] INTEGER REFERENCES pergunta([id]) ON DELETE RESTRICT ON UPDATE NO ACTION, 
			[id_item] INTEGER REFERENCES item([id]) ON DELETE CASCADE ON UPDATE CASCADE, 
			[imagem] VARCHAR(30), 
			[resposta] BOOL);");
		}

		void InsertDatas ()
		{
			//Insert into item
			ExecuteNonQuery (@"
			INSERT INTO [item]([id], [nome]) VALUES(1, 'extintor-sin-chao-err');
			INSERT INTO [item]([id], [nome]) VALUES(2, 'extintor-sin-cor-err');
			INSERT INTO [item]([id], [nome]) VALUES(3, 'extintor-alto-err');
			INSERT INTO [item]([id], [nome]) VALUES(4, 'extintor-baixo-err');
			INSERT INTO [item]([id], [nome]) VALUES(5, 'extintor-chao-err');
			INSERT INTO [item]([id], [nome]) VALUES(6, 'extintor-chao-ok');
			INSERT INTO [item]([id], [nome]) VALUES(7, 'extintor-sin-alto-err');
			INSERT INTO [item]([id], [nome]) VALUES(8, 'extintor-sin-baixo-err');
			INSERT INTO [item]([id], [nome]) VALUES(9, 'elevador-sin-alt-err');
			INSERT INTO [item]([id], [nome]) VALUES(10, 'elevador-sin-err');
			INSERT INTO [item]([id], [nome]) VALUES(11, 'elevador-sin-ok');
			INSERT INTO [item]([id], [nome]) VALUES(12, 'porta-sin-err');
			INSERT INTO [item]([id], [nome]) VALUES(13, 'porta-sin-cor-err');
			INSERT INTO [item]([id], [nome]) VALUES(14, 'extintor-ok');
			INSERT INTO [item]([id], [nome]) VALUES(15, 'porta-sin-cor-ok');
			INSERT INTO [item]([id], [nome]) VALUES(16, 'porta-sin-ok');
			INSERT INTO [item]([id], [nome]) VALUES(17, 'luminaria_desligada');
			INSERT INTO [item]([id], [nome]) VALUES(18, 'luminaria_ligada');
			INSERT INTO [item]([id], [nome]) VALUES(19, 'luminaria_ok');");			
			/* Table data [pergunta] Record count: 8 */
			ExecuteNonQuery (@"
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(1, 'Esta sinalização de piso está correta?', 'A sinalização de piso correta é vermelha com bordas amarelas.', '12693', 'Sistemas de proteção por extintores de incêndio');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(2, 'A cor desta sinalização de parede está correta?', 'A cor correta da sinalização de parede (placa) é vermelha.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(3, 'A altura desta sinalização de parede está correta?', 'A altura correta da sinalização de parede do extintor é de 1,80m.', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(4, 'A altura do extintor está correta?', 'A altura do extintor não deve exceder 1,60m. A parte inferior deve ter no mínimo, 0,20m de distância do piso.', '12693 ', 'Sistemas de proteção por extintores de incêndio');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(5, 'Esta sinalização está correta?', 'A sinalização correta para porta com barras antipânico é verde, escrito “Aperte e empurre”, anexada na própria porta com altura de 1,20m.', '13434-1 ', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(6, 'A sinalização acima dela está correta?', 'A sinalização correta, a seta aponta para cima(frente), acima da porta com barras antipânico.', '13434-1 ', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(7, 'No cénario atual, a luminária de emergência está correta?', 'A luminária de emergência tem de estar conectada na tomada e apagada.', '10898 ', 'Sistema de iluminação de emergência');
			INSERT INTO [pergunta]([id], [descricao], [explicacao], [nbr], [titulo]) VALUES(8, 'Está sinalização está correta?', 'A placa correta deve estar anexada ao lado do elevador a 1,80m do piso, escrito “Em caso de incêndio', '13434-1', 'Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto');");
			/* Table data [quiz] Record count: 18 */
			ExecuteNonQuery (@"
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(1, 1, 14, 'extintor_sin_chao_1', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(2, 1, 1, 'extintor_sin_chao_2', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(3, 2, 2, 'extintor_sin_cor_1', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(4, 2, 2, 'extintor_sin_cor_2', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(5, 5, 13, 'porta_sin_cor_2', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(6, 5, 12, 'porta_sin_cor_1', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(7, 4, 5, 'extintor_alt_4', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(8, 4, 3, 'extintor_alt_1', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(9, 4, 14, 'extintor_alt_2', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(10, 4, 6, 'extintor_alt_3', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(11, 3, 14, 'extintor_sin_alt_1', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(12, 3, 7, 'extintor_sin_alt_2', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(13, 3, 8, 'extintor_sin_alt_3', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(14, 7, 18, 'lumn_1', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(15, 7, 19, 'lumn_2', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(16, 7, 17, 'lumn_3', 0);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(17, 6, 16, 'porta_sin_top_1', 1);
			INSERT INTO [quiz]([id], [id_pergunta], [id_item], [imagem], [resposta]) VALUES(18, 6, 12, 'porta_sin_top_2', 0);");
			//make foreign key
			//ExecuteNonQuery (@"");
		}
	}
}