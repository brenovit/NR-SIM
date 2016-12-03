using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GerenciadorEvento : MonoBehaviour
{
	public GameObject panelCheckList;
	public GameObject panelQuiz;
	public GameObject panelDetalhe;

	public Text lblChecklist;
	private bool ativado = false;

	public UIBlock UiBlock;

	public void MostrarCheckList ()
	{
		ativado = !ativado;
		panelCheckList.SetActive (ativado);
	}

	public void FecharPainel ()
	{
		panelQuiz.SetActive (false);
		panelDetalhe.SetActive (false);
		UiBlock.SetActive (false);
	}

}
