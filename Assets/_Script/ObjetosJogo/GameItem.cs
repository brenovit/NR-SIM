using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;
using System.Collections.Generic;
using System.Linq;

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
		public GameObject UiBlock;

		public bool jaRespondeu = false;

		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
			itemManager = GameObject.FindGameObjectWithTag ("GM").GetComponent<ItensManager> ();

			item = new Item ();
			item.Nome = this.gameObject.name;
			item.ID = db.GetID (item.Nome);
		}

		void OnMouseDown ()
		{
			if (!jaRespondeu) {
				itemManager.MostraQuiz (this);
			} else {
				itemManager.MostraExplicacao (this);
			}
			UiBlock.SetActive (true);
		}
	}
}
