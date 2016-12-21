using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(BoxCollider2D))]
public class AbrirPorta : MonoBehaviour
{
	private Vector3 mousePosition;
	public MovePlayer jogador;
	public Transform target;

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
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
		/*print (col.tag);
		print ("Entrei");
		if (col.tag.Equals ("Player")) {
			print ("Entrei");
			col.gameObject.transform.position = target.position;
		}*/
	}
}
