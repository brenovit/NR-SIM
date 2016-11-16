using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public GameObject jogador;
	private Vector3 equilibrio;
	private Vector3 camera;

	public float maxima;
	public float minima;

	// Use this for initialization
	void Start ()
	{
		if (jogador == null) {
			jogador = GameObject.FindGameObjectWithTag ("Player");
		}
		camera = this.transform.position;

		equilibrio = jogador.transform.position - camera;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		camera = jogador.transform.position + equilibrio;
		camera.y = 0;
		camera.z = -10;

		if (camera.x > maxima) {
			camera.x = maxima;
		}
		if (camera.x < minima) {
			camera.x = minima;
		}
			
		this.transform.position = camera;
	}
}
