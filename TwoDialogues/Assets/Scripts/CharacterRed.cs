using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRed : MonoBehaviour {

	private Rigidbody2D myRB;
	static private float moveSpeed = 7;
	private bool facingRight;
	private bool canMove;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		facingRight = true;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		// if character is in an important conversation, "canMove" will be false
		if (canMove) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector2 movement = new Vector2 (moveHorizontal, myRB.velocity.y);

			myRB.velocity = movement * moveSpeed;
			if ((moveHorizontal > 0) && !facingRight)
				flip ();
			else if ((moveHorizontal < 0) && facingRight)
				flip ();
		}
	}

	void flip () {
		facingRight = !facingRight;
		// transform.localScale.x *= -1;
		transform.Rotate(new Vector2(0,180));
	}

	public void disableMovement() {
		canMove = false;
	}

	public void enableMovement() {
		canMove = true;
	}
}







