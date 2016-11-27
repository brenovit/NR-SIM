using UnityEngine;
using System.Collections;
using System.Text;

namespace ObjetoTransacional
{
	public class Pergunta
	{
		private string descricao;
		private string explicacao;
		private string titulo;

		public int ID {
			get;
			set;
		}

		public string Descricao {
			get {
				return descricao;
			}

			set {				
				descricao = string.Format ("{0}", value.ToString ());
			}
		}

		public string Explicacao {
			get {
				return explicacao;
			}
			set {
				explicacao = value.ToString ();
			}	

		}

		public string NBR {
			get;
			set;
		}

		public string Titulo {
			get {
				return titulo;
			}
			set {
				titulo = value.ToString ();
			}
		}

		public override string ToString ()
		{
			return string.Format ("[Pergunta: ID={0}, Descricao={1}, Explicacao={2}, NBR={3}, Titulo={4}]", ID, Descricao, Explicacao, NBR, Titulo);
		}
	}
}