using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
	public DataManager dataManager;
	public List<string> nomeCenas;

	void Start(){
		Debug.Assert (dataManager != null, "DataManager cannot be null");
		foreach (string cena in nomeCenas) {
			dataManager.DeletarArquivo (cena);
		}
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

