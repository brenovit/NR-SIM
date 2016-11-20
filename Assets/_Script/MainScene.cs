using UnityEngine;
using System.Collections;
using SQLiter;
using System.Collections.Generic;

public class MainScene : MonoBehaviour
{
	private List<Item> lista;

	void Awake ()
	{

	}

	void Start ()
	{
		lista = new List<Item> ();
		foreach (Item item in lista) {
			print (item.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
