using UnityEngine;
using System.Collections;
using ObjetoTransacional;
using UnityEngine.UI;
using System.Linq;
using System.Text;

namespace ObjetosJogo
{
	public class GameItemReflex
	{
		public string Nome;
		public Quiz Quiz;
		public bool jaRespondeu;

		public GameItemReflex(string nome, Quiz quiz, bool resposta){
			this.Nome = nome;
			this.Quiz = quiz;
			this.jaRespondeu = resposta;
		}

		public GameItemReflex(){
		}
	}
}