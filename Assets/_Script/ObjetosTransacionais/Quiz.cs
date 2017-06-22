using UnityEngine;
using System.Collections;

namespace ObjetoTransacional
{
	public class Quiz
	{
		public Quiz(){

		}

		public Quiz (int id, int id_pergunta, int id_item, string imagem, bool resposta)
		{
			this.ID = id;
			this.Pergunta = new Pergunta () { ID = id_pergunta };
			this.Item = new Item () { ID = id_item };
			this.Imagem = imagem;
			this.Resposta = resposta;
			
		}

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

		public override string ToString ()
		{
			return string.Format ("[Quiz: ID={0}, Pergunta={1}, Item={2}, Imagem={3}, Resposta={4}]", ID, Pergunta, Item, Imagem, Resposta);
		}
	}
}