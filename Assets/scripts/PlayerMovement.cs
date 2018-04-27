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

	private float horizontalSpeed;

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

		horizontalSpeed = Input.GetAxis("Horizontal");
	}

	void FixedUpdate () {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
			if(!_hanging) {
				rigidbody.velocity = new Vector2(horizontalSpeed * speed * (running ? runningModifier : 1), rigidbody.velocity.y);
				rigidbody.gravityScale = 1f;
			}
			else{
				if(rigidbody.velocity.y < 0) {
					rigidbody.gravityScale += 5f * Time.deltaTime;
				}
				else {
					rigidbody.gravityScale -= 5f * Time.deltaTime;
				}
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag == "Floor")
			jumping = false;
	}
}
