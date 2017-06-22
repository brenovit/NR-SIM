using UnityEngine;
using System.Collections;
using ObjetoTransacional;
using System.Collections.Generic;
using System.Linq;

namespace ObjetosJogo
{
	[RequireComponent (typeof(BoxCollider2D))]
	public class GameItem : MonoBehaviour
	{
		public string nome;
		//private DBItem db;
		public Quiz quiz;

		public ItensManager itemManager;

		public bool jaRespondeu = false;

		void Start ()
		{			
			itemManager = GameObject.FindGameObjectWithTag ("GM").GetComponent<ItensManager> ();
		}

		void OnMouseDown ()
		{
			if (!jaRespondeu) {
				itemManager.MostraQuiz (this);
			} else {
				itemManager.MostraExplicacao (this);
			}
		}

		public void Destroy ()
		{
			print ("Detruido: " + this.name);
			Destroy (this);
		}
	}
}
