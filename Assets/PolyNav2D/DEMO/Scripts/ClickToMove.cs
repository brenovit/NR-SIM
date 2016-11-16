using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent (typeof(PolyNavAgent))]
public class ClickToMove : MonoBehaviour
{
	
	private PolyNavAgent _agent;

	public PolyNavAgent agent {
		get {
			if (!_agent)
				_agent = GetComponent<PolyNavAgent> ();
			return _agent;			
		}
	}

	void Update ()
	{
		Vector3 mousePosition = Input.mousePosition;
		if (Input.GetMouseButton (0)) {
			mousePosition.z = agent.gameObject.transform.position.z;
			agent.SetDestination (Camera.main.ScreenToWorldPoint (mousePosition));
		}
	}
}