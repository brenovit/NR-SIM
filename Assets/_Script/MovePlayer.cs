/* 
 * Esse Script movimenta o GameObject quando você clica ou
 * mantém o botão esquerdo do mouse apertado.
 * 
 * Para usá-lo, adicione esse script ao gameObject que você quer mover
 * seja o Player ou outro
 * 
 * Autor: Vinicius Rezendrix - Brasil
 * Data: 11/08/2012
 * 
 * This script moves the GameObeject when you
 * click or click and hold the LeftMouseButton
 * 
 * Simply attach it to the gameObject you wanna move (player or not)
 * 
 * Autor: Vinicius Rezendrix - Brazil
 * Data: 11/08/2012 
 *
 */
 
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

	private Transform myTransform;
	// this transform
	private Vector3 destino;
	// The destination Point
	private float distanciaDestino;
	// The distance between myTransform and destinationPosition
	public float velocidade;
	// The Speed the character will move
	public bool andando;
	public Animator animator;
	public SpriteRenderer view;

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
		
		//print ("Jogador: " + myTransform.position.ToString ());

		if (myTransform.position != destino) {			
			
			distanciaDestino = Vector3.Distance (destino, myTransform.position);
			//print ("Distancia: " + distanciaDestino.ToString ());

			if (distanciaDestino < 0.5) {
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
}