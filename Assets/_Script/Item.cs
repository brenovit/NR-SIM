using UnityEngine;
using System.Collections;
using SQLiter;

public class Item : MonoBehaviour
{
	private DBItem db;
	public int ID;
	public string Nome;

	void Awake ()
	{

	}

	void Start ()
	{
		db = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBItem> ();
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

	public override string ToString ()
	{
		return this.ID + " - " + this.Nome;
	}
}
