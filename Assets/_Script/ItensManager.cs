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
	public GameObjectQuiz gOQuiz;
	public GameObjectPergunta gOPergunta;
	public Sprite[] imagens;

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

	public void Responder (bool resposta)
	{			
		GameManager.AdicionarPontos (resposta == gOQuiz.quiz.Resposta ? 200 : 0);
		gOQuiz.painel.SetActive (false);
	}

	public void MostraQuiz (Quiz quiz)
	{
		gOQuiz.quiz = quiz;
		gOQuiz.pergunta.text = quiz.Pergunta.Descricao;
		gOQuiz.resposta = quiz.Resposta;

		//busca no vetor de imagens a imagem que tem o mesmo nome que o objeto quiz retornado do banco
		//se tiver ele atribui a imagem do quiz(canvas) a imagem do vetor;
		for (int i = 0; i < imagens.Count (); i++) {
			if (imagens [i].name == quiz.Imagem) {
				gOQuiz.imagem.sprite = imagens [i];
				break;
			}
		}

		gOQuiz.painel.SetActive (true);

	}

	public void MostraExplicacao (Quiz quiz)
	{
		gOPergunta.titulo.text = quiz.Pergunta.NBR + " " + quiz.Pergunta.Titulo;
		gOPergunta.explicacao.text = quiz.Pergunta.Explicacao;
		gOPergunta.painel.SetActive (true);
	}
}
