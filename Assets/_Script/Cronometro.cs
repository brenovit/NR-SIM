using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
	public Text label;
	private string tempo;
	public float minutos;
	float tempSeg = 10;
	static int segundos = 0;
	//private static Cronometro instance = null;
	void LateUpdate ()
	{
		tempSeg = tempSeg + Time.deltaTime;
		segundos = (int)tempSeg;

		if (segundos == 0) {
			tempSeg = 60;
			minutos++;
		}

		/*if (minutos == 0 && segundos == 0) {
			Application.Quit ();
		}*/

		tempo = string.Format ("{0}:{1}", minutos.ToString ("00"), segundos.ToString ("00"));
		label.text = tempo;
	}
}
