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
	public class DBQuiz : MonoBehaviour
	{
		private DataBase db = null;
		private DBPergunta dbP = null;
		private DBItem dbI = null;

		public bool DebugMode = false;

		private const string SQL_TABLE_NAME = "quiz";

		private const string COL_ID = "id";
		private const string COL_PERGUNTA = "id_pergunta";
		private const string COL_ITEM = "id_item";
		private const string COL_IMAGEM = "imagem";
		private const string COL_RESPOTA = "reposta";

		private IDataReader mReader = null;
		private string mSQLString;

		void Start ()
		{			
			db = gameObject.GetComponent<DataBase> ().GetInstance ();
			dbP = gameObject.GetComponent<DBPergunta> ();
			dbI = gameObject.GetComponent<DBItem> ();

			if (DebugMode) {
				Debug.Log (db.ToString ());
				Debug.Log (dbP.ToString ());
				Debug.Log (dbI.ToString ());
			}
		}

		public void Insert (Quiz q)
		{
			// note - this will replace any item that already exists, overwriting them.  
			// normal INSERT without the REPLACE will throw an error if an item already exists
			mSQLString = "INSERT OR REPLACE INTO " + SQL_TABLE_NAME
			+ " ("
			+ COL_PERGUNTA + ","
			+ COL_ITEM + ","
			+ COL_IMAGEM + ","
			+ COL_RESPOTA
			+ ") VALUES ('"
			+ q.Pergunta.ID + "'"// note that string values need quote or double-quote delimiters
			+ "'" + q.Item.ID + "'"
			+ "'" + q.Imagem + "'"
			+ "'" + q.Resposta + "'"
			+ ");";

			if (DebugMode)
				Debug.Log (mSQLString);
			db.ExecuteNonQuery (mSQLString);
		}

		/// <summary>
		/// Quick method to show how you can query everything.  Expland on the query parameters to limit what you're looking for, etc.
		/// </summary>
		public List<Quiz> GetAllQuiz ()
		{
			List<Quiz> lista = new List<Quiz> ();
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, id_pergunta, id_item, imagem, resposta FROM " + SQL_TABLE_NAME;
			mReader = db.ExecuteQuery (mSQLString);
			while (mReader.Read ()) {
				Quiz q = new Quiz ();
				q.ID = mReader.GetInt32 (0);
				//procura a pergunta na tabela de pergunta pelo id da pergunta
				q.Pergunta = dbP.GetPergunta (mReader.GetInt32 (1));
				//procura o item na tabela de itens pelo id do item
				q.Item = dbI.GetItem (mReader.GetInt32 (2));
				q.Imagem = mReader.GetString (3);
				q.Resposta = mReader.GetBoolean (4);
				lista.Add (q);

				// view our output
				if (DebugMode)
					Debug.Log (q.ToString ());
			}
			return lista;
		}

		/// <summary>
		/// Rotina para procurar um quiz pelo id do item
		/// </summary>
		/// <returns>The quiz.</returns>
		/// <param name="i">Objeto Item com ID</param>
		public List<Quiz> GetQuiz (Item i)
		{
			List<Quiz> lista = null;
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, id_pergunta, id_item, imagem, resposta FROM " + SQL_TABLE_NAME +
			" WHERE " + COL_ITEM + "=" + i.ID;
			mReader = db.ExecuteQuery (mSQLString);
			while (mReader.Read ()) {
				Quiz q = new Quiz ();
				q.ID = mReader.GetInt32 (0);

				Pergunta p = new Pergunta ();
				p.ID = mReader.GetInt32 (1);
				q.Pergunta = p;
							
				q.Item = i;

				q.Imagem = mReader.GetString (3);
				q.Resposta = mReader.GetBoolean (4);
				lista.Add (q);

				// view our output
				if (DebugMode)
					Debug.Log (q.ToString ());
			}
			return lista;
		}

	}
}