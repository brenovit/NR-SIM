using UnityEngine;
using System.Collections;
using ObjetoTransacional;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//Text que irá mostrar os pontos
	public Text lblPontos;
	public static int pontos = 0;
	//Text que irá mostrar o cronometro
	public Text lblCronometro;
	//variavel temporaria para o segundo
	private static float tempSeg = 60;
	private int segundos = 0;
	public int minutos;
	private string tempo;

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
		tempSeg = tempSeg - Time.deltaTime;	//tempSeg decrementa de acordo com o Delta.Time(~1)
		segundos = (int)tempSeg;	//segundos recebe o valor de tempSeg em inteiro

		if (segundos == 60) {		//se o segundos for igual a 60
			tempSeg = 0;			//zera a tempSeg
			minutos--;				//decrementa o minuto
		}

		if (minutos == 0 && segundos == 0) { //se o tempo acabar
			//a fase encerra e começa de novo
		}
		//persiste os valores de minutos e segundos
		PlayerPrefs.SetInt ("minuto", minutos);
		PlayerPrefs.SetInt ("segundos", segundos);
		//atribui a uma string os valores de minutos e segundos
		tempo = string.Format ("{0}:{1}", minutos.ToString ("00"), segundos.ToString ("00"));
		//atribui ao Texto de lblCronometro o valor do tempo
		lblCronometro.text = tempo;
	}


}
