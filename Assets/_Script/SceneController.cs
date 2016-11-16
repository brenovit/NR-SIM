using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
	public GameObject player;
	private Vector3 playerPosition;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update ()
	{
		playerPosition = player.transform.position;

		//print ("Antes: " + playerPosition.ToString ());

		float x = playerPosition.x;
		float y = playerPosition.y;
		float z = playerPosition.z;

		if (y > -0.9) {
			z = 0.3f;
		} else if (y < -1.5 && y > -2.7) {
			z = 0.0f;
		} else if (y < -3.4 && y > -4.4) {
			z = -0.6f;
		} else if (y < -5.15) {
			z = -0.9f;
		}

		playerPosition.x = x;
		playerPosition.y = y;
		playerPosition.z = z;

		//print ("Depois: " + playerPosition.ToString ());

		player.transform.position = playerPosition;
	}
}