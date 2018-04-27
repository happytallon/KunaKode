using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float jumpingForce = 250f;
	public float speed = 5;
	public float runningModifier = 1.5f;

	private Rigidbody2D rigidbody;
	private bool jumping = false; public bool isJumping {get {return jumping;}}
	private bool running = false;
	private bool _hanging = false; public bool isHanging {get {return _hanging;} set{_hanging = value;}}

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update(){		
		if(!jumping && !_hanging && Input.GetKeyDown(KeyCode.Space)){
			rigidbody.AddForce(new Vector2(0, jumpingForce));
			jumping = true;
		}

		if(!running && Input.GetKeyDown(KeyCode.LeftShift))
			running = true;
		if(running && Input.GetKeyUp(KeyCode.LeftShift))
			running = false;
	}

	void FixedUpdate () {
		var x = Input.GetAxis("Horizontal");
		rigidbody.velocity = new Vector2(x * speed * (running ? runningModifier : 1), rigidbody.velocity.y);
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag == "Floor")
			jumping = false;
	}
}
