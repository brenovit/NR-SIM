using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instancia = null;
	public string cenaUI;
	public int pontos;

	private UIManager uiManager;

	// Use this for initialization
	void Awake ()
	{	
		if (!PlayerPrefs.HasKey ("pontos")) {
			PlayerPrefs.SetInt ("pontos", pontos);
			pontos = 0;
		} else {
			pontos = PlayerPrefs.GetInt ("pontos");
		}
		SceneManager.LoadScene (cenaUI, LoadSceneMode.Additive);
	}

	void Start ()
	{
		uiManager = FindObjectOfType<UIManager> ();
		uiManager.SetPontos (pontos);
		//PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
