using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;

namespace ObjetosJogo
{
	[RequireComponent (typeof(BoxCollider2D))]
	public class GameItem : MonoBehaviour
	{
		public string nome;
		private DBItem db;
		public Quiz quiz;
		[HideInInspector]
		public Item item;
		public ItensManager itemManager;
		private bool jaRespondeu = false;

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
			if (!jaRespondeu) {
				itemManager.MostraQuiz (quiz);
				jaRespondeu = true;
			} else {
				itemManager.MostraExplicacao (quiz);
			}

		}
	}
}
