using UnityEngine;
using System.Collections;
using SQLiter;
using System.Collections.Generic;

public class MainScene : MonoBehaviour
{
	private Persistencia db;
	private List<Item> lista;

	void Awake ()
	{
		db = this.GetComponent<Persistencia> ().GetInstance ();
	}

	void Start ()
	{
		lista = db.GetAllItens ();
		foreach (Item item in lista) {
			print (item.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
