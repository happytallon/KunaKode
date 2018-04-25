using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update(){		
		if(Input.GetKeyDown(KeyCode.Space)){
			Debug.Log("lol");
			rigidbody.AddForce(new Vector2(0, 250));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		var x = Input.GetAxis("Horizontal");
		rigidbody.velocity = new Vector2(x * 5, rigidbody.velocity.y);

	}
}
