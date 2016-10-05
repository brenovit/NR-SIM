using UnityEngine;
using System.Collections;

// <summary>
/// This class represent the game floor. The area that the player can put or remove the towers.
/// </summary>/
public class Floor : MonoBehaviour
{
	private Vector3 mousePosition;
	public GameObject player;

	void Awake ()
	{
		player = new GameObject ();
	}

	void OnMouseDown ()
	{
		/*Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector2 origin = new Vector2 (ray.origin.x, ray.origin.y);
			RaycastHit2D hit = Physics2D.Linecast (origin, -Vector2.up);//, 1 << LayerMask.NameToLayer ("Towers"));*/
		//GameObject selectorAux = GameObject.FindGameObjectWithTag ("Selector");	

		print ("Toquei no Chão");
		///towerSelect.Action (GameMode.Building);	//muda o layout do jogo para o modo contrução, caso clique em um lugar livre.
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);	//recebe a posição do clique do mouse
		mousePosition.z = -1;

		//selector.InstantiateAt (mousePosition);	//instantiate the selector, using a static metod from the selector class, at mousePosition location
	}
}