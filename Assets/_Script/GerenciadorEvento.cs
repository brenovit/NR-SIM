using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GerenciadorEvento : MonoBehaviour
{
	public GameObject panelCheckList;
	public GameObject panelQuiz;
	public GameObject panelDetalhe;

	private bool ativado = false;

	public void MostrarCheckList ()
	{
		ativado = !ativado;
		panelCheckList.SetActive (ativado);
		UiBlock.Ativar ();
	}

	public void FecharPainel ()
	{
		panelQuiz.SetActive (false);
		panelDetalhe.SetActive (false);
		UiBlock.Desativar ();
	}
}
