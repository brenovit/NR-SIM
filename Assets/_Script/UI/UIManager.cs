using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
	public static UIManager instancia = null;
	// This scene will loaded after whis level exit
	public string nomeCenaSair;
	// Pause menu canvas
	public GameObject panelPause;
	// Defeat menu canvas
	public GameObject panelDerrota;
	// Victory menu canvas
	public GameObject panelVitoria;
	public GameObject panelQuiz;
	public GameObject panelDescricao;
	public GameObject panelChecklist;
	// Level interface
	public GameObject panelBarraSuperior;
	// Avaliable points amount
	public Text lblPontos;
	public Text lblCronometro;
	//variavel temporaria para o segundo
	private static float tempSeg = 10;
	private int segundos = 0;
	public int minutos;
	private string tempo;

	void Start ()
	{
		if (PlayerPrefs.HasKey ("minutos")) {			
			minutos = PlayerPrefs.GetInt ("minutos");
		} else {
			print ("não tenho minuto");
			PlayerPrefs.SetInt ("minutos", minutos);
		}

		if (PlayerPrefs.HasKey ("segundos")) {
			segundos = PlayerPrefs.GetInt ("segundos");
		} else {
			PlayerPrefs.SetInt ("segundos", segundos);
		}
	}

	void LateUpdate ()
	{
		if (minutos <= 0 && segundos <= 0) {
			//panelFimJogo.SetActive (true);
			minutos = 0;
			segundos = 0;
			//Time.timeScale = 0;
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
		lblPontos.text = valor.ToString ("0000");
	}

	public int GetPontos ()
	{
		int pontos;
		int.TryParse (lblPontos.text, out pontos);
		return pontos;
	}

	public void FimJogo ()
	{
		
	}

	public void PauseGame ()
	{

	}

	public void Checklist ()
	{

	}

	public void BotaoPressionado (GameObject obj, string param)
	{
		switch (param) {
		case "Pausar":
			PauseGame ();
			break;
		case "Sair":		
			break;
		case "Voltar":
			break;
		case "Reiniciar":
			break;
		case "Checklist":
			Checklist ();
			break;
		}
	}


}