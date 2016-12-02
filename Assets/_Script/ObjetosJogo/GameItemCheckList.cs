using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ObjetoTransacional;

namespace ObjetosJogo
{
	/// <summary>
	/// Game pergunta. Esta classe representa o descritivo da pergunta
	/// </summary>
	public class GameItemCheckList : MonoBehaviour
	{
		public Button botao;
		public Text titulo;
		public Quiz quiz;
		public bool ativo = false;
		private ItensManager itemManager;

		private GameItem gameItem;

		// Use this for initialization
		void Start ()
		{
			itemManager = GameObject.FindGameObjectWithTag ("_GM").GetComponent<ItensManager> (); //instancio o objeto dbquiz
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (gameItem != null) {
				
				if (gameItem.jaRespondeu) {
					botao.interactable = true;
				}
			}
		}
			

		public void MostrarExplicacao(){
			itemManager.MostraExplicacao (gameItem);
		}

		public void EnviarQuiz(GameItem gameItem){
			this.gameItem = gameItem;
			titulo.text = gameItem.quiz.Pergunta.Titulo;
		}
	}
}