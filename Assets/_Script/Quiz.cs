using UnityEngine;
using System.Collections;

public class Quiz : MonoBehaviour
{
	public int ID;
	public Pergunta Pergunta;
	public Item Item;
	public string Imagem;
	public bool Resposta;

	private Item i;
	// Use this for initialization
	void Start ()
	{
		i = new Item ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
