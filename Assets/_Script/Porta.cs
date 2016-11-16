using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
	public string sala;

	public void IrSala ()
	{
		SceneManager.LoadScene (sala);
	}
}
