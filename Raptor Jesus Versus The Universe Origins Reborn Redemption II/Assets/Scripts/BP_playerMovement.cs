using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_playerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpHeight = 500;

	private bool facingRight = false;
	private float moveX;
	private Rigidbody2D rigidBody2D;
	public bool playerIsGrounded;

	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		playerMove();
	}

	void playerMove()
	{
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && playerIsGrounded)
		{
			playerJump();
		}

		//ANIMATIONS
		//PLAYER DIRECTIONS
		if (moveX < 0.0f && !facingRight)
		{
			playerFlip();
		}
		else if (moveX > 0.0f &&  facingRight)
		{
			playerFlip();
		}

		//PHYSICS
		rigidBody2D.velocity = new Vector2(moveX * playerSpeed, rigidBody2D.velocity.y);
	}

	void playerJump()
	{
		//JUMP
		rigidBody2D.AddForce(Vector2.up * playerJumpHeight);
		playerIsGrounded = false;

	}

	void playerFlip()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;

		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			playerIsGrounded = true;
		}
	}
}
