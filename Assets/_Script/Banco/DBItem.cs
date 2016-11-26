//----------------------------------------------
// SQLiter
// Copyright © 2014 OuijaPaw Games LLC
//----------------------------------------------

using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using System.Collections.Generic;
using ObjetoTransacional;

namespace SQLiter
{
	/// <summary>
	/// The idea is that here is a bunch of the basics on using SQLite
	/// Nothing is some advanced course on doing joins and unions and trying to make your infinitely normalized schema work
	/// SQLite is simple.  Very simple.  
	/// Pros:
	/// - Very simple to use
	/// - Very small memory footprint
	/// 
	/// Cons:
	/// - It is a flat file database.  You can change the settings to make it run completely in memory, which will make it even
	/// faster; however, you cannot have separate threads interact with it -ever-, so if you plan on using SQLite for any sort
	/// of multiplayer game and want different Unity instances to interact/read data... they absolutely cannot.
	/// - Doesn't offer as many bells and whistles as other DB systems
	/// - It is awfully slow.  I mean dreadfully slow.  I know "slow" is a relative term, but unless the DB is all in memory, every
	/// time you do a write/delete/update/replace, it has to write to a physical file - since SQLite is just a file based DB.
	/// If you ever do a write and then need to read it shortly after, like .5 to 1 second after... there's a chance it hasn't been
	/// updated yet... and this is local.  So, just make sure you use a coroutine or whatever to make sure data is written before
	/// using it.
	/// 
	/// SQLite is nice for small games, high scores, simple saved, etc.  It is not very secure and not very fast, but it's cheap,
	/// simple, and useful at times.
	/// 
	/// Here are some starting tools and information.  Go explore.
	/// </summary>
	public class DBItem : MonoBehaviour
	{
		private DataBase db = null;
		public bool DebugMode = false;

		// table name
		private const string SQL_TABLE_NAME = "item";

		/// <summary>
		/// predefine columns here to there are no typos
		/// </summary>
		private const string COL_ID = "id";
		private const string COL_NOME = "nome";

		private IDataReader mReader = null;
		private string mSQLString;

		void Start ()
		{
			db = gameObject.GetComponent <DataBase> ().GetInstance ();	//pega o gameobject que contem a classe Database
			if (DebugMode)
				Debug.Log (db.ToString ());
		}

		#region Insert

		/// <summary>
		/// Inserts a item into the database
		/// http://www.sqlite.org/lang_insert.html
		/// name must be unique, it's our primary key
		/// </summary>
		/// <param name="nome">nome do item</param>
		public void Insert (Item item)
		{
			// note - this will replace any item that already exists, overwriting them.  
			// normal INSERT without the REPLACE will throw an error if an item already exists
			mSQLString = "INSERT OR REPLACE INTO " + SQL_TABLE_NAME
			+ " ("
			+ COL_NOME
			+ ") VALUES ('"
			+ item.Nome + "'"// note that string values need quote or double-quote delimiters
			+ ");";

			if (DebugMode)
				Debug.Log (mSQLString);
			db.ExecuteNonQuery (mSQLString);
		}

		#endregion

		#region Query Values

		/// <summary>
		/// Quick method to show how you can query everything.  Expland on the query parameters to limit what you're looking for, etc.
		/// </summary>
		public List<Item> GetAllItens ()
		{
			List<Item> lista = new List<Item> ();
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, nome FROM " + SQL_TABLE_NAME;
			mReader = db.ExecuteQuery (mSQLString);

			while (mReader.Read ()) {
				Item item = new Item ();
				item.ID = mReader.GetInt32 (0);
				item.Nome = mReader.GetString (1);

				lista.Add (item);

				// view our output
				if (DebugMode)
					Debug.Log (item.ToString ());
			}
			return lista;
		}

		/// <summary>
		/// Quick method to show how you can query everything.  Expland on the query parameters to limit what you're looking for, etc.
		/// </summary>
		public Item GetItem (int id)
		{
			Item item = new Item ();
			// if you have a bunch of stuff, this is going to be inefficient and a pain.  it's just for testing/show
			mSQLString = "SELECT id, nome FROM " + SQL_TABLE_NAME + " WHERE " + COL_ID + " = '" + id + "'";
			mReader = db.ExecuteQuery (mSQLString);

			while (mReader.Read ()) {				
				item.ID = mReader.GetInt32 (0);
				item.Nome = mReader.GetString (1);
			
				// view our output
				if (DebugMode)
					Debug.Log (item.ToString ());
			}
			return item;
		}

		/// <summary>
		/// Basic get, returning a value, busca o id do item pelo nome
		/// </summary>
		/// <param name="value">nome do item</param>
		/// <returns></returns>
		public int GetID (string nome)
		{
			return QueryInt (COL_ID, new Item () { Nome = nome });
		}

		/// <summary>
		/// Supply the column and the value you're trying to find, and it will use the primary key to query the result
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public string QueryString (string coluna, Item item)
		{
			string text = "Not Found";
			mSQLString = "SELECT " + coluna + " FROM " + SQL_TABLE_NAME + " WHERE " + COL_NOME + "='" + item.Nome + "'";
			mReader = db.ExecuteQuery (mSQLString);
			if (mReader.Read ())
				text = mReader.GetString (0);
			else
				Debug.Log ("QueryString - nothing to read...");
			return text;
		}

		/// <summary>
		/// Supply the column and the value you're trying to find, and it will use the primary key to query the result
		/// </summary>
		/// <param name="column"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public int QueryInt (string coluna, Item item)
		{
			int sel = -1;
			mSQLString = "SELECT " + coluna + " FROM " + SQL_TABLE_NAME + " WHERE " + COL_NOME + "='" + item.Nome + "'";
			mReader = db.ExecuteQuery (mSQLString);
			if (mReader.Read ())
				sel = mReader.GetInt32 (0);
			else
				Debug.Log ("QueryInt - nothing to read...");
			return sel;
		}

		#endregion

		#region Update / Replace Values

		/// <summary>
		/// A 'Set' method that will set a column value for a specific player, using their name as the unique primary key
		/// to some value.  This currently just uses 'int' types, but you could modify this to use/do most anything.
		/// Remember strings need single/double quotes around their values
		/// </summary>
		/// <param name="value"></param>
		public void UpdateItem (string coluna, Item item)
		{
			db.ExecuteNonQuery ("UPDATE OR REPLACE " + SQL_TABLE_NAME + " SET " + coluna + "=" + item.Nome + " WHERE " + COL_ID + "='" + item.ID + "'");
		}

		#endregion

		#region Delete

		/// <summary>
		/// Basic delete, using the name primary key for the 
		/// </summary>
		/// <param name="nameKey"></param>
		public void Delete (Item item)
		{
			db.ExecuteNonQuery ("DELETE FROM " + SQL_TABLE_NAME + " WHERE " + COL_NOME + "='" + item.Nome + "'");
		}

		#endregion
	}
}