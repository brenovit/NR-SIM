using UnityEngine;
using System.Collections;

public class Sala1Controller : MonoBehaviour
{
	public GameObject player;
	private Vector3 playerPosition;

	public GameObject fila1;	//0 0.5 -1.5
	public GameObject fila2;	//0 -1.3 -1.5
	public GameObject fila3;	//0 -3.1 -1.5
	public GameObject mesa;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate ()
	{
		playerPosition = player.transform.position;

		//print ("Antes: " + playerPosition.ToString ());

		float y = playerPosition.y;

		if (y > -0.9) {
			//ACIMA DA FILEIRA 1 => -1.5
			fila1.transform.position = new Vector3(0, 0.5f, -1.5f);
		} else if (y < -1.4 && y > -2.7) {
			//ENTRE FILEIRA 1 E 2 => F1 = 0.5, F2=-1.5
			fila1.transform.position = new Vector3(0, 0.5f, 0.5f);
			fila2.transform.position = new Vector3(0, -1.3f, -1.5f);
		} else if (y < -3.0 && y > -4.3) {
			//ENTRE FILEIRA 2 E 3 => F2=0.5, F3=-1.5
			fila2.transform.position = new Vector3(0, -1.3f, 0.5f);
			fila3.transform.position = new Vector3(0, -3.1f, -1.5f);
		} else if (y < -5.0) {
			//ABAIXO DA FILEIRA 3 => F3=0.5
			fila3.transform.position = new Vector3(0, -3.1f, 0.5f);
		}

		if (y > -2.9) {
			mesa.transform.position = new Vector3 (5.8f, -3.65f, -1.5f); 
		} else if (y < -5.0) {
			mesa.transform.position = new Vector3 (5.8f, -3.65f, 0.5f); 
		}
			

		//print ("Depois: " + playerPosition.ToString ());

		//player.transform.position = playerPosition;
	}
}