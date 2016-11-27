using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EsconderPanel : MonoBehaviour
{
	public GameObject panel;
	public GameObject popUp;

	public void Ocultar ()
	{
		panel.SetActive (false);
		popUp.SetActive (true);

	}

}