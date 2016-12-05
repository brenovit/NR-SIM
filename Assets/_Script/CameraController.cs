using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public GameObject jogador;
	private Vector3 equilibrio;
	private Vector3 cameraPosition;

	public float maxima;
	public float minima;
	private float y;
	// Use this for initialization
	void Start ()
	{
		if (jogador == null) {
			jogador = GameObject.FindGameObjectWithTag ("Player");
		}
		cameraPosition = this.transform.position;
		y = cameraPosition.y;
		equilibrio = jogador.transform.position - cameraPosition;
		equilibrio.x = 0;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		cameraPosition = jogador.transform.position + equilibrio;
		cameraPosition.y = y;
		cameraPosition.z = -10;

		if (cameraPosition.x > maxima) {
			cameraPosition.x = maxima;
		}
		if (cameraPosition.x < minima) {
			cameraPosition.x = minima;
		}
			
		this.transform.position = cameraPosition;
	}
}
