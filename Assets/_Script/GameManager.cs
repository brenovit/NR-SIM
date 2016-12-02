﻿using UnityEngine;
using System.Collections;
using ObjetoTransacional;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Text lblPontos;
	public static int pontos = 0;

	void Update ()
	{
		lblPontos.text = (pontos).ToString ("0000");
	}

	/// <summary>
	/// Adicionars the pontos.
	/// </summary>
	/// <param name="valor">Valor.</param>
	public static void AdicionarPontos (int valor)
	{
		pontos += valor;
	}
}
