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
		if (ativado) {
			ativado = false;
			panelCheckList.SetActive (ativado);
		} else {
			ativado = true;
			panelCheckList.SetActive (ativado);
		}
	}

	public void MudarTexto ()
	{
		string msg = "Check-List: " +
		             "\n\n1.-------------------------------" +
		             "\n\n2.-------------------------------" +
		             "\n\n3.NBR 12693, Item 5.3" +
		             "\n\n4.-------------------------------" +
		             "\n\n5.-------------------------------";
		lblChecklist.text = msg;

	}
}
