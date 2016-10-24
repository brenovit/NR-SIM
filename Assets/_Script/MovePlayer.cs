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

public class MovePlayer : MonoBehaviour
{
	
	private Transform myTransform;
	// this transform
	private Vector3 destino;
	// The destination Point
	private float distanciaDestino;
	// The distance between myTransform and destinationPosition
	public float velocidade;
	//public float defaultSpeed;
	// The Speed the character will move
	public bool andando;
	public Animator animator;
	public SpriteRenderer view;

	void Start ()
	{
		myTransform = transform;						// sets myTransform to this GameObject.transform
		destino = myTransform.position;				// prevents myTransform reset
		//animator = myTransform.GetComponentsInChildren<Animator> ();
		//print ("Estou em: x: " + myTransform.position.x + " - y: " + myTransform.position.y + " - z: " + myTransform.position.z);
		//velocidade = defaultSpeed;
		//view = myTransform.GetComponentsInChildren <SpriteRenderer> ();
	}

	public void MoverAte(Vector3 destino){
		this.destino = destino;
	}

	void Update ()
	{		
		print ("Destino jogador: "+destino.ToString());
		print ("Jogador: "+myTransform.position.ToString());
		print ("Distancia: "+distanciaDestino.ToString());

		if (myTransform.position != destino) {
			animator.SetBool ("andando", false);
			distanciaDestino = Vector3.Distance (destino, myTransform.position);

			if (destino.x < myTransform.position.x) {				
				view.flipX = true;
			} else {
				view.flipX = false;
			}

			if (distanciaDestino > .1) {
				myTransform.position = Vector3.MoveTowards (myTransform.position, destino, velocidade * Time.deltaTime);
				animator.SetBool ("andando", true);
			} else {
				animator.SetBool ("andando", false);
			}
		}	
	}
}