using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;
using UnityEngine.UI;

namespace ObjetosJogo
{
	public class GameQuiz : MonoBehaviour
	{
		private DBQuiz db;
		public Sprite imagem;
		private Quiz quiz;
		public Text pergunta;
		private bool resposta;

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

		public void SendQuiz (Quiz quiz)
		{
			this.quiz = quiz;
			this.pergunta.text = quiz.Pergunta.Descricao;
			this.resposta = quiz.Resposta;
			gameObject.SetActive (true);
		}
	}
}