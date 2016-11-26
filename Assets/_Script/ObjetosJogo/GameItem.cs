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

		void Awake ()
		{

		}

		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
		}

		void Update ()
		{
		
		}

		void OnMouseDown ()
		{
			Debug.Log ("cliquei no quiz");
		}
	}
}
