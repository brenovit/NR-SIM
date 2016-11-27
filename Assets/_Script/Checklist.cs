using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{
	public GameObject panelCheckList;
	public Text lblChecklist;
	private bool ativado = false;

	public void MostrarCheckList ()
	{
		ativado = !ativado;
		panelCheckList.SetActive (ativado);
	}
}
