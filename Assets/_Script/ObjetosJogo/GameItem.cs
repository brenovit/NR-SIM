using UnityEngine;
using System.Collections;
using SQLiter;

namespace ObjetosJogo
{
	public class GameItem : MonoBehaviour
	{
		private DBItem db;

		void Awake ()
		{

		}

		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
			/*Nome = this.gameObject.name;
		print (Nome);
		ID = db.GetItem (Nome);
		print (ID);*/
		}

		void Update ()
		{
		
		}

		void OnMouseDown ()
		{
		
		}

		/*public override string ToString ()
	{
		return this.ID + " - " + this.Nome;
	}*/
	}
}
