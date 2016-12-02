using UnityEngine;
using System.Collections;
using SQLiter;
using System.Collections.Generic;
using ObjetoTransacional;
using ObjetosJogo;
using UnityEngine.UI;
using System.Linq;

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
	private List<Quiz> listaQuiz;
	private DBQuiz dbQuiz;
	private GameObject[] itens;
	public GameItemCheckList[] itemCheckList;

	public GameObjectQuiz gOQuiz;
	public GameObjectPergunta gOPergunta;
	public Sprite[] imagens;

	public GameItem gameItem;
	public GameObject checkList;

	void Start ()
	{
		dbQuiz = GameObject.FindGameObjectWithTag ("SQL").GetComponent<DBQuiz> (); //instancio o objeto dbquiz

		listaQuiz = dbQuiz.GetAllQuiz ();	//pego todos os quiz da base

		itens = GameObject.FindGameObjectsWithTag ("Item");	//pego todos os gameobject com a tag Item
		int x = 0;
		for (int i = 0; i < itens.Length; i++) {
			foreach (var quiz in listaQuiz) {
				if (itens [i].gameObject.GetComponent <GameItem> ().item.ID == quiz.Item.ID) {
					itens [i].gameObject.GetComponent <GameItem> ().quiz = quiz;
					if (x < itemCheckList.Count ()) {
						itemCheckList [x].EnviarQuiz (itens [i].gameObject.GetComponent <GameItem> ());
						x++;
					}
				}
			}
		}

		//comparo cada item na lista com cada 
		//agora que tenho a lista de todos os quiz, tenho que colocar cada um deles em um item.
		//para isso preciso pegar todos os itens.
	}

	/// <summary>
	/// Responder the specified resposta. Evento do Click
	/// </summary>
	/// <param name="resposta">If set to <c>true</c> resposta.</param>
	public void Responder (bool resposta)
	{			
		GameManager.AdicionarPontos (resposta == gOQuiz.quiz.Resposta ? 200 : 0);
		gameItem.jaRespondeu = true;
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

	public void AtivarCheckList (bool ativo)
	{
		checkList.SetActive (!ativo);
	}
}
