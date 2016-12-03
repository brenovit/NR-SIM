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
		public UIBlock UiBlock;

		public bool jaRespondeu = false;

		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
			item = new Item ();
			item.Nome = this.gameObject.name;
			item.ID = db.GetID (item.Nome);
			itemManager = GameObject.FindGameObjectWithTag ("_GM").GetComponent<ItensManager> ();
			UiBlock = GameObject.FindGameObjectWithTag ("UiBlock").GetComponent <UIBlock> ();
		}

		void OnMouseDown ()
		{
			UiBlock.SetActive (true);
			if (!jaRespondeu) {
				itemManager.MostraQuiz (this);
			} else {
				itemManager.MostraExplicacao (this);
			}
		}
	}
}
