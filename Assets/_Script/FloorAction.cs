using UnityEngine;
using System.Collections;

public class FloorAction : MonoBehaviour
{
	private Vector3 mousePosition;
	public MovePlayer jogador;

	void Start ()
	{
		if (jogador == null) {
			jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovePlayer> ();
		}
	}

	void OnMouseDown ()
	{	
		if (Input.GetMouseButtonDown (0)) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);	//recebe a posição do clique do mouse
			mousePosition.z = jogador.transform.position.z;
			jogador.MoverAte (mousePosition);
		}
		print ("Destino jogador: " + mousePosition.ToString ());
	}
}
