using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text lblPontos;
	public static int pontos = 0;

	void Update ()
	{
		lblPontos.text = (pontos).ToString ("0000");
	}

	public static void AdicionarPontos (int valor)
	{
		pontos += valor;
	}
}
