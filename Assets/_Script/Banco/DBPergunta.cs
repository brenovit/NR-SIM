using UnityEngine;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Mono.Data.SqliteClient;
using ObjetoTransacional;

namespace SQLiter
{
	/// <summary>
	/// DB pergunta. Classe para manipular a tabela de pergunta
	/// </summary>
	public class DBPergunta : MonoBehaviour
	{
		private DataBase db = null;
		public bool DebugMode = false;

		private const string SQL_TABLE_NAME = "pergunta";

		private const string COL_ID = "id";
		private const string COL_NBR = "nbr";
		private const string COL_TITULO = "titulo";
		private const string COL_DESCRICAO = "descricao";
		private const string COL_EXPLICACAO = "explicacao";

		private IDataReader mReader = null;
		private string mSQLString;

		void Start ()
		{
			db = gameObject.GetComponent<DataBase> ().GetInstance ();
			if (DebugMode)
				Debug.Log (db.ToString ());
		}

		public void Insert (Pergunta p)
		{
			// note - this will replace any item that already exists, overwriting them.  
			// normal INSERT without the REPLACE will throw an error if an item already exists
			mSQLString = "INSERT OR REPLACE INTO " + SQL_TABLE_NAME
			+ " ("
			+ COL_DESCRICAO + ","
			+ COL_EXPLICACAO + ","
			+ COL_NBR + ","
			+ COL_TITULO
			+ ") VALUES ('"
			+ p.Descricao + "'"// note that string values need quote or double-quote delimiters
			+ "'" + p.Explicacao + "'"
			+ "'" + p.NBR + "'"
			+ "'" + p.Titulo + "'"
			+ ");";

			if (DebugMode)
				Debug.Log (mSQLString);
			db.ExecuteNonQuery (mSQLString);
		}

		/// <summary>
		/// Quick method to show how you can query everything.  Expland on the query parameters to limit what you're looking for, etc.
		/// </summary>
		public List<Pergunta> GetAllPerguntas ()
		{
			List<Pergunta> lista = new List<Pergunta> ();
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, descricao, explicacao, titulo, nbr FROM " + SQL_TABLE_NAME;
			mReader = db.ExecuteQuery (mSQLString);
			while (mReader.Read ()) {
				Pergunta p = new Pergunta ();
				p.ID = mReader.GetInt32 (0);
				p.Descricao = mReader.GetString (1);
				p.Explicacao = mReader.GetString (2);
				p.Titulo = mReader.GetString (3);
				p.NBR = mReader.GetString (4);
				lista.Add (p);

				// view our output
				if (DebugMode)
					Debug.Log (p.ToString ());
			}
			return lista;
		}

		/// <summary>
		/// Quick method to show how you can query everything.  Expland on the query parameters to limit what you're looking for, etc.
		/// </summary>
		public Pergunta GetPergunta (int id)
		{
			Pergunta p = new Pergunta ();
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, descricao, explicacao, titulo, nbr FROM " + SQL_TABLE_NAME +
			" WHERE " + COL_ID + " = '" + id + "'";
			mReader = db.ExecuteQuery (mSQLString);
			while (mReader.Read ()) {
				p.ID = mReader.GetInt32 (0);
				p.Descricao = mReader.GetString (1);
				p.Explicacao = mReader.GetString (2);
				p.Titulo = mReader.GetString (3);
				p.NBR = mReader.GetString (4);

				// view our output
				if (DebugMode)
					Debug.Log (p.ToString ());
			}
			return p;
		}

	}
}