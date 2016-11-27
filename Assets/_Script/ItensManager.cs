using UnityEngine;
using System.Collections;
using SQLiter;
using System.Collections.Generic;
using ObjetoTransacional;
using ObjetosJogo;

public class ItensManager : MonoBehaviour
{
	private List<Quiz> listaQuiz;
	private DBQuiz dbQuiz;
	private GameObject[] itens;

	void Awake ()
	{
		
	}

	void Start ()
	{
		dbQuiz = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBQuiz> (); //instancio o objeto dbquiz

		listaQuiz = dbQuiz.GetAllQuiz ();	//pego todos os quiz da base

		itens = GameObject.FindGameObjectsWithTag ("Item");	//pego todos os gameobject com a tag Item

		for (int i = 0; i < itens.Length; i++) {
			foreach (var quiz in listaQuiz) {
				if (itens [i].gameObject.GetComponent <GameItem> ().item.ID == quiz.Item.ID) {
					itens [i].gameObject.GetComponent <GameItem> ().quiz = quiz;
				}
			}
		}

		//comparo cada item na lista com cada 
		//agora que tenho a lista de todos os quiz, tenho que colocar cada um deles em um item.
		//para isso preciso pegar todos os itens.
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
