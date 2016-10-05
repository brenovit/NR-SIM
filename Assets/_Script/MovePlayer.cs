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
	private Vector3 mousePosition;
	private Transform myTransform;
	// this transform
	private Vector3 destinationPosition;
	// The destination Point
	private float destinationDistance;
	// The distance between myTransform and destinationPosition
	private float moveSpeed;
	public float defaultSpeed;
	// The Speed the character will move
	public bool andando;
	public Animator animator;
	public SpriteRenderer view;

	void Start ()
	{
		myTransform = transform;						// sets myTransform to this GameObject.transform
		mousePosition = myTransform.position;			// prevents myTransform reset
		//animator = myTransform.GetComponentsInChildren<Animator> ();
		//print ("Estou em: x: " + myTransform.position.x + " - y: " + myTransform.position.y + " - z: " + myTransform.position.z);
		moveSpeed = defaultSpeed;
		//view = myTransform.GetComponentsInChildren <SpriteRenderer> ();
	}

	void Update ()
	{
		animator.SetBool ("andando", false);
		destinationDistance = Vector3.Distance (mousePosition, myTransform.position);

		// Moves the Player if the Left Mouse Button was clicked
		if (Input.GetMouseButtonDown (0) && GUIUtility.hotControl == 0) {
			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);	//recebe a posição do clique do mouse
			mousePosition.z = 0;
			if (mousePosition.x < myTransform.position.x) {				
				view.flipX = true;
			} else {
				view.flipX = false;
			}

			if (mousePosition.y >= -0.4f) {
				mousePosition.y = -0.4f;
			}

		}

		if (destinationDistance > .1) {
			myTransform.position = Vector3.MoveTowards (myTransform.position, mousePosition, moveSpeed * Time.deltaTime);
			animator.SetBool ("andando", true);
		} else {
			animator.SetBool ("andando", false);
		}

		// To prevent code from running if not needed
		//if (destinationDistance > .5f) 
		//myTransform.position = Vector3.MoveTowards (myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		
	}
}