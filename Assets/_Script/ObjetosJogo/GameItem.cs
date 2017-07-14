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
		public string Nome;
		public Quiz Quiz;

		public ItensManager itemManager;

		public bool jaRespondeu = false;

		void Start ()
		{			
			itemManager = FindObjectOfType<ItensManager> ();
			Nome = this.gameObject.name;
		}

		public void MouseDown ()
		{
			print ("cliquei em:" + Nome);
			itemManager.MostrarPanel (this);
		}
	}
}
