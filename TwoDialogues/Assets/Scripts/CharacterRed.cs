using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRed : MonoBehaviour {

	public Rigidbody2D myRB;
	static public float moveSpeed = 7;
	public bool facingRight;
	private 

	// Use this for initialization
	void Start () {
		// myRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, myRB.velocity.y);

		myRB.velocity = movement * moveSpeed;
		if ((moveHorizontal > 0) && !facingRight)
			flip ();
		else if ((moveHorizontal < 0) && facingRight)
			flip ();
	}

	void flip () {
		facingRight = !facingRight;
		// transform.localScale.x *= -1;
		transform.Rotate(new Vector2(0,180));
	}
}







