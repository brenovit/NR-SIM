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

[System.Serializable]
public class GameObjectQuiz
{
	public GameObject painel;
	public Text pergunta;
	public Image imagem;
	public bool resposta;
	public Quiz quiz;
}

[System.Serializable]
public class GameObjectPergunta
{
	public GameObject painel;
	public Text titulo;
	public Text explicacao;
}

public class ItensManager : MonoBehaviour
{
	private string nomeCena;
	private List<Quiz> listaQuiz;
	public DataManager dataManager;

	private GameObject[] itensCena;

	public GameItemCheckList[] itemCheckList;

	public GameObjectQuiz gOQuiz;

	public GameObjectPergunta gOPergunta;

	public Sprite[] imagens;

	private GameItem gameItem;

	void Start ()
	{
		nomeCena = SceneManager.GetActiveScene ().name;
		listaQuiz = DefaultData.ObjetosDefault ();//dataManager.CarregarLista (nomeCena);			//carrego a lista de itens deste cenario
		itensCena = GameObject.FindGameObjectsWithTag ("Item");			//pego todos os gameobject com a tag Item

		if (listaQuiz.Count() <= 0) {
			//lista ta vazia
		} else {
			foreach (var item in itensCena) {
				GameItem gameItem = item.GetComponent<GameItem> ();
				//gameItem.quiz = 
			}
		}

		//dbQuiz = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBQuiz> (); 					//instancio o objeto dbquiz

		//

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
	/// Responder the specified resposta. Evento do Click
	/// </summary>
	/// <param name="resposta">If set to <c>true</c> resposta.</param>
	public void Responder (bool resposta)
	{
		//GameManager.AdicionarPontos (resposta == gOQuiz.quiz.Resposta ? 200 : 0);
		gameItem.jaRespondeu = true;
		UiBlock.Desativar ();
		gOQuiz.painel.SetActive (false);
	}

	/// <summary>
	/// Mostras the quiz. Evento de Click
	/// </summary>
	/// <param name="quiz">Quiz.</param>
	public void MostraQuiz (GameItem gameItem)
	{
		this.gameItem = gameItem;
		gOQuiz.quiz = gameItem.quiz;
		gOQuiz.pergunta.text = gameItem.quiz.Pergunta.Descricao;
		gOQuiz.resposta = gameItem.quiz.Resposta;

		//busca no vetor de imagens a imagem que tem o mesmo nome que o objeto quiz retornado do banco
		//se tiver ele atribui a imagem do quiz(canvas) a imagem do vetor;
		for (int i = 0; i < imagens.Count (); i++) {
			if (imagens [i].name == gameItem.quiz.Imagem) {
				gOQuiz.imagem.sprite = imagens [i];
				break;
			}
		}
		gOQuiz.painel.SetActive (true);
	}

	/// <summary>
	/// Mostras the explicacao. Evento de Clicks
	/// </summary>
	/// <param name="quiz">Quiz.</param>
	public void MostraExplicacao (GameItem gameItem)
	{
		gOPergunta.titulo.text = gameItem.quiz.Pergunta.NBR + " " + gameItem.quiz.Pergunta.Titulo;
		gOPergunta.explicacao.text = gameItem.quiz.Pergunta.Explicacao;
		gOPergunta.painel.SetActive (true);
	}
}
