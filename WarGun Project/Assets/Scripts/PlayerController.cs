using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 3f;
	float velX;
	float velY;
	bool facingRight = true;
	Rigidbody2D rigBody;
	Animator anim;
	bool isRunning = false;


	// Use this for initialization
	void Start () {

		rigBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		velX = Input.GetAxisRaw ("Horizontal");
		velY = rigBody.velocity.y;
		rigBody.velocity = new Vector2 (velX * moveSpeed, velY);

		if (velX != 0) {

			isRunning = true;
		
		} else {
		
			isRunning = false;

		}

		anim.SetBool ("isRunning", isRunning);
	}

	void LateUpdate(){

		Vector3 localScale = transform.localScale;
		if (velX > 0) {

			facingRight = true;

		}else if(velX < 0){

			facingRight = false;
		}

		if ((facingRight == true) && (localScale.x < 0)) {

			localScale.x *= -1;
		
		} else if ((facingRight == false) && (localScale.x > 0)) {

			localScale.x *= -1;
		}

		transform.localScale = localScale;
	}
}
