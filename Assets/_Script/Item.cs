using UnityEngine;
using System.Collections;
using SQLiter;

public class Item : MonoBehaviour
{
	private Persistencia db;
	public int ID;
	public string Nome;

	void Awake ()
	{
		db = GameObject.FindGameObjectWithTag ("_GM").GetComponent<Persistencia> ().GetInstance ();
	}

	void Start ()
	{
		Nome = this.gameObject.name;
		print (Nome);
		ID = db.GetItem (Nome);
		print (ID);
	}

	void Update ()
	{
		
	}

	void OnMouseDown ()
	{
		
	}

	public string ToString ()
	{
		return this.ID + " - " + this.Nome;
	}
}
