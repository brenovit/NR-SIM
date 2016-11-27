using UnityEngine;
using System.Collections;
using SQLiter;
using ObjetoTransacional;
using UnityEngine.UI;
using System.Linq;
using System.Text;

namespace ObjetosJogo
{
	public class GameQuiz : MonoBehaviour
	{
		private DBQuiz db;
		private Quiz quiz;
		public Text pergunta;
		private bool resposta;
		public Image imagem;
		public Sprite[] imagens;

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
			GameManager.AdicionarPontos (resposta == quiz.Resposta ? 200 : 0);
			gameObject.SetActive (false);
		}

		public void SendQuiz (Quiz quiz)
		{
			this.quiz = quiz;
			this.pergunta.text = quiz.Pergunta.Descricao;
			this.resposta = quiz.Resposta;

			//busca no vetor de imagens a imagem que tem o mesmo nome que o objeto quiz retornado do banco
			//se tiver ele atribui a imagem do quiz(canvas) a imagem do vetor;
			for (int i = 0; i < imagens.Count (); i++) {
				if (imagens [i].name == quiz.Imagem) {
					imagem.sprite = imagens [i];
					break;
				}
			}

			gameObject.SetActive (true);

		}
	}
}