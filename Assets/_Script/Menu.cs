using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	public void CarregarCena (string cena)
	{
		SceneManager.LoadScene (cena);
	}

	public void Sair ()
	{
		Application.Quit ();
	}
}
