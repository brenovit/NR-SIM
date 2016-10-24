using UnityEngine;
using System.Collections;

public class FloorAction : MonoBehaviour {

	private Vector3 mousePosition;
	public MovePlayer jogador;

	void Start(){
		if (jogador == null) {
			jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovePlayer>();
		}
	}

	void OnMouseDown (){	
		if (Input.GetMouseButtonDown (0)) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);	//recebe a posição do clique do mouse
			mousePosition.z = 0;
			jogador.MoverAte (mousePosition);
		}
		print ("Em: "+mousePosition.ToString());
	}
}
