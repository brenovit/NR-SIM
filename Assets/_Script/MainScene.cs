using UnityEngine;
using System.Collections;
using SQLiter;
using System.Collections.Generic;
using ObjetoTransacional;

public class MainScene : MonoBehaviour
{
	private List<Quiz> listaQuiz;
	private DBQuiz dbQuiz;

	void Awake ()
	{
		
	}

	void Start ()
	{
		dbQuiz = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBQuiz> ();

		listaQuiz = dbQuiz.GetAllQuiz ();
		foreach (var item in listaQuiz) {
			print (item.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
