using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(BoxCollider2D))]
public class AbrirPorta : MonoBehaviour
{
	private Vector3 mousePosition;
	public MovePlayer jogador;
	public Transform target;
	public float cameraPositionX;
	private Camera camera;
	private Vector3 cameraPosition;

	void Start ()
	{
		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovePlayer> ();
		camera = Camera.main;
		cameraPosition = camera.gameObject.transform.position;
		cameraPosition.x = cameraPositionX;
		print (cameraPosition);
	}

	/*void OnMouseDown ()
	{	
		if (Input.GetMouseButtonDown (0)) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);	//recebe a posição do clique do mouse
			mousePosition.z = jogador.transform.position.z;
			jogador.MoverAte (mousePosition);
		}
	}*/

	void OnTriggerEnter2D (Collider2D col)
	{		
		if (col.tag.Equals ("Player")) {
			col.gameObject.transform.position = target.position;
			camera.gameObject.transform.position = cameraPosition;
		}
	}
}
