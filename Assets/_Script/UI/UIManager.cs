using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using ObjetosJogo;

[System.Serializable]
public class GameObjectQuiz{
	public Image imagem;
	public Text pergunta;
}
[System.Serializable]
public class GameObjectDescricao{
	public Text titulo;
	public Text descricao;
}
public class UIManager : MonoBehaviour
{
	// This scene will loaded after whis level exit
	public string nomeCenaSair;
	// Pause menu canvas
	public GameObject panelPause;
	// Defeat menu canvas
	public GameObject panelGameOver;
	// Victory menu canvas
	public GameObject panelGameWon;
	// Level interface
	public GameObject panelBarraSuperior;
	// Confirmation restart level canvas
	public GameObject panelConfirmarReiniciar;
	// Confirmation Exit level canvas
	public GameObject panelConfirmarSair;
	public GameObject panelQuiz;
	public GameObject panelDescricao;
	public GameObject panelChecklist;

	public GameObjectQuiz goQuiz;
	public GameObjectDescricao goDescricao;

	public Sprite[] imagensQuiz;

	// Avaliable points amount
	public Text lblPontos;
	public Text lblCronometro;
	//variavel temporaria para o segundo
	private static float tempSeg = 10;
	private int segundos = 0;
	public int minutos;
	private string tempo;

	private bool checklistVisivel = false;
	private GameItem localGameItem;
	public int pontosAcerto;
	public ListItemChecklist listaGameItemCheclist;

	private int pontos;
	private int itensRespondidos;
	public int totalItens;

	void OnEnable(){
		GerenciadorEvento.CriarEvento ("BotaoPressionado",BotaoPressionado); 
		GerenciadorEvento.CriarEvento ("GameOver",GameOver); 
		GerenciadorEvento.CriarEvento ("GameWon",GameWon); 
	}

	void OnDisable(){
		GerenciadorEvento.RemoverEvento ("BotaoPressionado",BotaoPressionado);
		GerenciadorEvento.RemoverEvento ("GameOver",GameOver);
		GerenciadorEvento.RemoverEvento ("GameWon",GameWon);
	}

	void Start ()
	{
		if (PlayerPrefs.HasKey ("minutos")) {			
			minutos = PlayerPrefs.GetInt ("minutos");
		} else {
			PlayerPrefs.SetInt ("minutos", minutos);
		}

		if (PlayerPrefs.HasKey ("segundos")) {
			segundos = PlayerPrefs.GetInt ("segundos");
		} else {
			PlayerPrefs.SetInt ("segundos", segundos);
		}

		if (PlayerPrefs.HasKey ("pontos")) {
			pontos = PlayerPrefs.GetInt ("pontos");
		} else {
			PlayerPrefs.SetInt ("pontos", pontos);
		}
		if (PlayerPrefs.HasKey ("itensRespondidos")) {
			itensRespondidos = PlayerPrefs.GetInt ("itensRespondidos");
		} else {
			PlayerPrefs.SetInt ("itensRespondidos", itensRespondidos);
		}
	}

	void LateUpdate ()
	{
		if (minutos <= 0 && segundos <= 0) {
			//panelFimJogo.SetActive (true);
			minutos = 0;
			segundos = 0;
			Time.timeScale = 0;
			panelGameOver.SetActive (true);
			//UiBlock.Ativar ();
		} else {
			tempSeg = tempSeg - Time.deltaTime;		//tempSeg decrementa de acordo com o Delta.Time(~1)
			if (segundos == 0) {					//se o segundos for igual a 60
				tempSeg = 60;						//zera a tempSeg
				minutos--;							//decrementa o minuto
			}
			segundos = (int)tempSeg;				//segundos recebe o valor de tempSeg em inteiro
		}
		PlayerPrefs.SetInt ("minutos", minutos);
		PlayerPrefs.SetInt ("segundos", segundos);
		PlayerPrefs.Save ();
		tempo = string.Format ("{0}:{1}", minutos.ToString ("00"), segundos.ToString ("00"));
		//atribui ao Texto de lblCronometro o valor do tempo
		lblCronometro.text = tempo;
	}

	public void AddPontos (int valor)
	{
		SetPontos (GetPontos () + valor);
	}

	public void SetPontos (int valor)
	{
		pontos = valor;
		lblPontos.text = valor.ToString ("0000");
	}

	public int GetPontos ()
	{
		int pontos;
		int.TryParse (lblPontos.text, out pontos);
		return pontos;
	}

	public void Checklist ()
	{
		checklistVisivel = !checklistVisivel;
		panelChecklist.SetActive (checklistVisivel);
	}

	public void BotaoPressionado (GameObject obj, string param)
	{
		switch (param) {
		case "Pausar":
			Pausar ();
			break;
		case "Resumir":
			Resumir ();
			break;
		case "Sair":
			Sair ();
			break;
		case "Reiniciar":
			Reiniciar ();
			break;
		case "ConfirmarReiniciar":
			ConfirmarReiniciar();
			break;
		case "ConfirmarSair":
			ConfirmarSair();
			break;
		case "VoltarConfirmarSair":
			VoltarConfirmarSair();
			break;
		case "VoltarConfirmarReiniciar":
			VoltarConfirmarReiniciar();
			break;
		case "Efeito":
			Efeito ();
			break;
		case "Musica":
			Musica ();
			break;
		case "Checklist":
			Checklist ();
			break;
		}
	}

	public void Pausar()
	{
		panelPause.SetActive (true);
		Time.timeScale = 0;
	}

	public void Sair ()
	{
		panelConfirmarSair.SetActive (true);
	}

	public void Reiniciar ()
	{
		panelConfirmarReiniciar.SetActive (true);
	}

	public void Resumir ()
	{
		panelPause.SetActive (false);
		Time.timeScale = 1;
	}

	public void ConfirmarReiniciar ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void ConfirmarSair ()
	{
		SceneManager.LoadScene (nomeCenaSair);
	}

	public void VoltarConfirmarSair ()
	{
		panelConfirmarSair.SetActive (false);
	}

	public void VoltarConfirmarReiniciar ()
	{
		panelConfirmarReiniciar.SetActive (false);
	}

	public void Efeito(){
		GerenciadorEvento.ExecutarEvento ("MuteEffect", null, "");
	}

	public void Musica(){
		GerenciadorEvento.ExecutarEvento ("MuteMusic", null, "");
	}

	public void GameOver(GameObject obj, string param){
		Time.timeScale = 0;
		panelGameOver.SetActive (true);
	}

	public void GameWon(GameObject obj, string param){
		Time.timeScale = 0;
		panelGameWon.SetActive (true);
	}

	public void FecharQuiz(){
		panelQuiz.SetActive (false);
		localGameItem = null;
	}


	public void FecharDescricao(){
		panelDescricao.SetActive (false);
		localGameItem = null;
	}

	public void Responder(bool resposta){
		if (resposta == localGameItem.Quiz.Resposta) {
			AddPontos (pontosAcerto);
			//mostra obj norma sucesso
		} else {
			//mostra obj norma fracasso
		}
		GerenciadorEvento.ExecutarEvento ("SalvarLista", null, "");
		panelQuiz.SetActive (false);
		localGameItem.jaRespondeu = true;
		localGameItem = null;
		ItemRespondido ();
	}

	private void ItemRespondido(){
		itensRespondidos++;
		PlayerPrefs.SetInt ("itensRespondidos", itensRespondidos);
		if (itensRespondidos == totalItens) {
			GerenciadorEvento.ExecutarEvento ("GameWon",null,""); 
		}
		print (itensRespondidos+"/"+totalItens);
	}

	public void MostrarPainel(GameItem gameItem){
		localGameItem = gameItem;
		if (localGameItem != null) {
			if (localGameItem.jaRespondeu) {
				goDescricao.descricao.text = localGameItem.Quiz.Pergunta.Explicacao;
				goDescricao.titulo.text = localGameItem.Quiz.Pergunta.NBR + " " + localGameItem.Quiz.Pergunta.Titulo;
				panelDescricao.SetActive (true);
			} else {
				for (int i = 0; i < imagensQuiz.Length; i++) {
					if (imagensQuiz [i].name == localGameItem.Quiz.Imagem) {
						goQuiz.imagem.sprite = imagensQuiz [i];
						break;
					}
				}
				goQuiz.pergunta.text = localGameItem.Quiz.Pergunta.Descricao;
				panelQuiz.SetActive (true);
			}
		}
	}
}