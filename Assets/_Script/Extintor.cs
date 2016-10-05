using UnityEngine;
using System.Collections;

public class Extintor : MonoBehaviour
{
	public GameObject pergunta;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseDown ()
	{
		pergunta.SetActive (true);
	}
}
