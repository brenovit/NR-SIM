using UnityEngine;
using System.Collections;
using ObjetoTransacional;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//Text que irá mostrar os pontos
	public Text lblPontos;
	public static int pontos = 0;
	//Text que irá mostrar o cronometro
	public Text lblCronometro;
	//variavel temporaria para o segundo
	private static float tempSeg = 60;
	private int segundos = 60;
	public int minutos;
	private string tempo;
	//GO para mostrar a mensagemd de fim de jogo
	public GameObject panelFimJogo;

	void Awake ()
	{
		Time.timeScale = 1;
		panelFimJogo.SetActive (false);
	}

	void Start ()
	{
		//manter o horario na troca de cenas
		if (PlayerPrefs.HasKey ("minutos") && PlayerPrefs.HasKey ("segundos")) {	//verifica se os dados persistidos de minutos e segundos existem
			segundos = PlayerPrefs.GetInt ("segundos");	//atribui valores
			minutos = PlayerPrefs.GetInt ("minutos");	//atribuit valores
		}
	}

	void Update ()
	{
		lblPontos.text = (pontos).ToString ("0000"); //altera continuamente os pontos
	}

	/// <summary>
	/// Adicionars the pontos.
	/// </summary>
	/// <param name="valor">Valor.</param>
	public static void AdicionarPontos (int valor)
	{
		pontos += valor;
	}

	void LateUpdate ()
	{
		if (minutos <= 0 && segundos <= 00) {
			panelFimJogo.SetActive (true);
			minutos = 0;
			segundos = 0;
			Time.timeScale = 0;
			UiBlock.Ativar ();
		} else {
			tempSeg = tempSeg - Time.deltaTime;		//tempSeg decrementa de acordo com o Delta.Time(~1)
			segundos = (int)tempSeg;				//segundos recebe o valor de tempSeg em inteiro

			if (segundos == 00) {					//se o segundos for igual a 60
				tempSeg = 60;						//zera a tempSeg
				minutos--;							//decrementa o minuto
			}
		}

		//persiste os valores de minutos e segundos
		PlayerPrefs.SetInt ("minuto", minutos);
		PlayerPrefs.SetInt ("segundos", segundos);
		//atribui a uma string os valores de minutos e segundos
		tempo = string.Format ("{0}:{1}", minutos.ToString ("00"), segundos.ToString ("00"));
		//atribui ao Texto de lblCronometro o valor do tempo
		lblCronometro.text = tempo;
	}

	public void CarregarCena (string cena)
	{
		SceneManager.LoadScene (cena);
	}
}
