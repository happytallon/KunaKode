using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{	
	public GameObject hookPrefab;
	public int hookSpeed;

	private Rigidbody2D rigidbody;	

	private GameObject hook;
	private Vector2 hookTarget;
	
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		hookTarget = transform.position;
	}
	
	void FixedUpdate () {
		var x = Input.GetAxis("Horizontal");
		rigidbody.velocity = new Vector2(x, 0) * 5;

		if(Input.GetButtonDown("Fire1")){
 			GameObject projectile = Instantiate( hookPrefab, transform.position, Quaternion.identity);

			//Rotation
			Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
     		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
     		projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			//Movement
			//Debug.Log(projectile.transform.forward);
			Vector3 shootDirection;
 			shootDirection = Input.mousePosition;
 			shootDirection.z = 0.0f;
 			shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
 			shootDirection = shootDirection-transform.position;
 			//...instantiating the rocket
 			//Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
 			projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * hookSpeed, shootDirection.y * hookSpeed);
		}
	}
}
