using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EsconderPanel : MonoBehaviour
{
	public GameObject panel;
	public GameObject popUp;
	public Text lblPontos;

	public int pontos = 200;

	private bool ativo = false;

	public void Ocultar ()
	{
		panel.SetActive (false);
		popUp.SetActive (true);
		lblPontos.text = (pontos += 200).ToString ("0000");
	}

}