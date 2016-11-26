using UnityEngine;
using System.Collections;

namespace ObjetoTransacional
{
	public class Quiz
	{
		public int ID {
			get;
			set;
		}

		public Pergunta Pergunta {
			get;
			set;
		}

		public Item Item {
			get;
			set;
		}

		public string Imagem {
			get;
			set;
		}

		public bool Resposta {
			get;
			set;
		}
	}
}