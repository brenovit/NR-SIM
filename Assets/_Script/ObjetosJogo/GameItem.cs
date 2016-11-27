using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;

namespace ObjetosJogo
{
	public class GameItem : MonoBehaviour
	{
		public string nome;
		private DBItem db;
		public Quiz quiz;
		[HideInInspector]
		public Item item;
		public GameQuiz gQuiz;

		void Awake ()
		{
			
		}

		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
			item = new Item ();
			item.Nome = this.gameObject.name;
			item.ID = db.GetID (item.Nome);

			//gQuiz = GameObject.FindGameObjectWithTag ("Quiz").GetComponent<GameQuiz> ();
		}

		void Update ()
		{
			
		}

		void OnMouseDown ()
		{
			gQuiz.SendQuiz (quiz);
		}
	}
}
