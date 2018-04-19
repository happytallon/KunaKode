using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
	public GameObject RopePrefab;

	private Vector3 initialPosition;
	private GameObject nextNode;

	void Start () {
		initialPosition = transform.position;
	}
	
	void FixedUpdate ()
	{
		var distanceTraveled = Vector3.Distance(transform.position, initialPosition);
		//Debug.Log(distanceTraveled);
		if(distanceTraveled > 0.25f && nextNode == null){
			nextNode = Instantiate(RopePrefab, initialPosition, transform.rotation);
			nextNode.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
		}
	}
}
