using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(BoxCollider2D))]
public class Porta : MonoBehaviour
{
	//nome da cena que está porta ira carregar
	public string cenaDestino;
	//status da porta
	private bool aberta;

	void Start ()
	{
		aberta = false;	//ao iniciar a porta fica fechada
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {		//verifica o evento de click do mouse
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);		//captura o raio do evento
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);	//faz uma atribuição ao evento, partindo da origem do click(camera) até o inifinito
			if (hit) {
				if (hit.collider.gameObject == this.gameObject) {	//verifica se o objeto clicado é a porta
					aberta = true;	//define que essa porta será aberta
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{		
		if (col.tag.Equals ("Player") && aberta) {	//caso o collider seja do jogador e a mesma estiver aberta			
			SceneManager.LoadScene (cenaDestino);	//troca de cena
		}
	}
}
