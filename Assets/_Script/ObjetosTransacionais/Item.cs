using UnityEngine;
using System.Collections;

namespace ObjetoTransacional
{
	public class Item
	{
		public int ID { 
			get; 
			set;
		}

		public string Nome { 
			get; 
			set;
		}

		public override string ToString ()
		{
			return string.Format ("[Item: ID={0}, Nome={1}]", ID, Nome);
		}
	}
}