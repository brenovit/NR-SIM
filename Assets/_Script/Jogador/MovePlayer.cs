using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PolyNavAgent))]
public class MovePlayer : MonoBehaviour
{
	private PolyNavAgent _agent;

	public PolyNavAgent agent {
		get {
			if (!_agent)
				_agent = GetComponent<PolyNavAgent> ();
			return _agent;			
		}
	}
	// this transform
	private Transform myTransform;
	// The destination Point
	private Vector3 destino;
	// The distance between myTransform and destinationPosition
	private float distanciaDestino;
	// The Speed the character will move
	public float velocidade;
	public Animator animator;
	//imagem do jogador
	public SpriteRenderer view;
	private Vector3 mousePosition;

	void Start ()
	{
		myTransform = transform;						// sets myTransform to this GameObject.transform
		destino = myTransform.position;				// prevents myTransform reset
	}

	public void MoverAte (Vector3 destino)
	{
		this.destino = destino;
	}

	void Update ()
	{
		if (myTransform.position != destino) {
			distanciaDestino = Vector3.Distance (destino, myTransform.position);

			if (distanciaDestino < 0.5) {	//se a distancia for inferio a 0.5 altera o status do jogador
				animator.SetBool ("andando", false);
			} else {
				animator.SetBool ("andando", true);
			}

			if (destino.x < myTransform.position.x) {				
				view.flipX = true;
			} else {
				view.flipX = false;
			}

			agent.SetDestination (destino);
		}
	}

	void FixedUpdate(){		
		if (Input.GetMouseButtonDown (0)) {														//verifica o clique do mouse			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);						//captura o raio do evento
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);	//faz uma atribuição ao evento, partindo da origem do click(camera) até o inifinito
			if (hit) {
				string gOTag = hit.collider.gameObject.tag;
				if (gOTag.Contains ("Porta") || gOTag.Equals ("Chao")) {						//verifica se o objeto clicado é a porta
					mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);		//recebe a posição do clique do mouse
					mousePosition.z = transform.position.z;
					MoverAte (mousePosition);											//faz o jogador andar até o local clicado
				}
			}
		}
	}
}