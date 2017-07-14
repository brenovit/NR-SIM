using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public DataManager dataManager;

	void Start(){
		Debug.Assert (dataManager != null, "DataManager cannot be null");
	}

	public void CarregarCena (string cena)
	{
		CriarDados ();
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene (cena);
	}

	public void Sair ()
	{
		Application.Quit ();
	}

	private void CriarDados(){
		dataManager.CriarArquivoDefault ();
	}
}

