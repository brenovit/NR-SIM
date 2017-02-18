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

	void FixedUpdate ()
	{
		if (Input.GetMouseButtonDown (0)) {														//verifica o clique do mouse
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);						//captura o raio do evento
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);	//faz uma atribuição ao evento, partindo da origem do click(camera) até o inifinito
			if (hit) {
				string gOName = hit.collider.gameObject.name;
				if (gOName.Contains ("Porta") || gOName.Equals ("Chao")) {						//verifica se o objeto clicado é a porta
					mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);		//recebe a posição do clique do mouse
					mousePosition.z = jogador.transform.position.z;
					jogador.MoverAte (mousePosition);											//faz o jogador andar até o local clicado
				}
			}
		}
	}
}
