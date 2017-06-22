using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlador : MonoBehaviour
{

	public void BotaoPressionado (string nomeBotao)
	{
		GerenciadorEvento.ExecutarEvento ("BotaoPressionado", gameObject, nomeBotao);
	}
}
