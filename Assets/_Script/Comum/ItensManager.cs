using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ObjetoTransacional;
using ObjetosJogo;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using SaveGameFree;

public class ItensManager : MonoBehaviour
{
	private string nomeCena;
	public DataManager dataManager;

	public List<GameItem> itensCena;

	public List<GameItemCheckList> itensCheckList;

	//private GameItem gameItem;
	private List<GameItem> listaGameItem;
	public UIManager uimanager;
	void Start ()
	{
		Saver.Initialize (FormatType.XML);
		
		nomeCena = SceneManager.GetActiveScene ().name;
		List<Quiz> listaQuiz = DefaultData.ObjetosDefault ();
		itensCena = FindObjectsOfType<GameItem> ().ToList ();
		uimanager = FindObjectOfType<UIManager>();
		itensCheckList = Resources.FindObjectsOfTypeAll<GameItemCheckList> ().ToList();
		listaGameItem = dataManager.CarregarListaGameItem(nomeCena);

		if (listaGameItem == null || listaGameItem.Count == 0) {
			foreach (GameItem item in itensCena) {
				item.Quiz = listaQuiz.Where (x => x.Item.Nome == item.Nome).FirstOrDefault ();
			}
		} else {			
			foreach (GameItem item in itensCena) {
				GameItem gi = listaGameItem.Where (x => x.Nome == item.Nome).FirstOrDefault ();
				item.Quiz = gi.Quiz;
				item.jaRespondeu = gi.jaRespondeu;
			}
		}

//		int i = 0;
//		foreach (var item in itemCheckList) {
//			item.EnviarQuiz (itensCena [i]);
//			i++;
//		}

		//int x = 0;

		/*for (int i = 0; i < itens.Length; i++) {													//verifica todos os itens
			GameItem item = itens [i].gameObject.GetComponent<GameItem> ();							//pega o componente Gameitem do item atual
			listaQuiz = dbQuiz.GetQuizByItemID (item.item);											//vai no banco e busca os quiz associados  ao item atual
			if (listaQuiz.Count > 0) {																//se a lista não retornar vazia
				int index = Convert.ToInt32 (UnityEngine.Random.Range (0, listaQuiz.Count - 1));	//seleciona um registro
				item.quiz = listaQuiz.ElementAt (index);											//atribui ao quiz do item selecionado o item na lista na posição index
				if (x < itemCheckList.Count ()) {
					itemCheckList [x].EnviarQuiz (item);
					x++;
				} else {
					item.Destroy ();
					break;
				}
			}
		}*/
	}

	/// <summary>
	/// Mostras the quiz. Evento de Click
	/// </summary>
	/// <param name="quiz">Quiz.</param>
	public void MostrarPanel (GameItem gameItem)
	{
		uimanager.MostrarPainel (gameItem);
	}
}
