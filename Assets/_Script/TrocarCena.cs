using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(BoxCollider2D))]
public class TrocarCena : MonoBehaviour
{
	public string cena;

	void OnMouseDown ()
	{
		SceneManager.LoadScene (cena);
	}
}
