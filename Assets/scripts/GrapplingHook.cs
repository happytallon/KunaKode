using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {
	
	DistanceJoint2D joint;
	Vector3 targetPos;
	RaycastHit2D hit;
	public float distance = 10f;
	public LayerMask mask;
	
	// Use this for initialization
	void Start () {
		joint = GetComponent<DistanceJoint2D> ();
		joint.enabled = false;
		//line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPos.z = 0;

			hit = Physics2D.Raycast(transform.position, targetPos - transform.position,distance, mask);

			if(hit.collider != null){
				Debug.Log("hit collider");
				Debug.Log(hit.collider.gameObject.name);
				if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
					Debug.Log("compomnent");
			}
			if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null){
				Debug.Log("oi");
				joint.enabled = true;
				joint.connectedBody=hit.collider.gameObject.GetComponent<Rigidbody2D>();
				joint.distance = Vector2.Distance(transform.position, hit.point);
			}			
		}
		if(Input.GetKeyUp(KeyCode.E)){
			joint.enabled = false;
		}
	}
}
