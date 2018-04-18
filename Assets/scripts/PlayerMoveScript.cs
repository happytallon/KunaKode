using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{	
	public GameObject hook;
	public int shootForce;
	private Rigidbody2D rigidbody;	
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		var x = Input.GetAxis("Horizontal");
		rigidbody.velocity = new Vector2(x, 0) * 5;

		if(Input.GetButtonDown("Fire1")){
			Debug.Log("111");
			if(GameObject.Find("Hook") != null) return;

			Vector2 direction = Input.mousePosition - transform.position;
 			direction.Normalize();
 			GameObject projectile = Instantiate( hook, transform.position, Quaternion.identity);
 			projectile.GetComponent<Rigidbody2D>().velocity = direction * shootForce;
		}
	}
}
