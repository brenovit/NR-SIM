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
			get {
				return Nome;
			} 
			set { 
				Nome = Nome.ToLower ();
			}
		}
	}
}