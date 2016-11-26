using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;

namespace ObjetosJogo
{
	public class GameQuiz : MonoBehaviour
	{
		/*public int ID;
		public string Descricao;
		public string Explicacao;
		public string NBR;
		public string Titulo;*/
		private DBQuiz db;
		public Sprite imagem;
		public GamePergunta pergunta;
		private Quiz quiz;

		// Use this for initialization
		void Start ()
		{
			db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBQuiz> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Responder (bool resposta)
		{
			//se a resposta estiver certa
			//mostra uma mensagem
			//senão
			//mostra outra
		}
	}
}