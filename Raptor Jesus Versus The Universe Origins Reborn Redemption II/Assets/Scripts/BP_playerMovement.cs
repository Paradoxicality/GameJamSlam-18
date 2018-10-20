using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_playerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpHeight = 500;
	public float bounceOnEnemy = 0.9f;

	private bool facingRight = false;
	private float playerMoveX;
	private Rigidbody2D playerRigidBody2D;
	public bool playerIsGrounded;
	BP_playerScore playerScoreAdd;
	GameObject enemy;
	BP_enemyIncScore enemyScore;


	void Start()
	{
		playerRigidBody2D = GetComponent<Rigidbody2D>();
		playerScoreAdd = gameObject.GetComponent<BP_playerScore>();
		enemy = GameObject.FindGameObjectWithTag("Enemy");
		enemyScore = enemy.GetComponent<BP_enemyIncScore>();
	}

	// Update is called once per frame
	void Update () {
		playerMove();
		playerRayCast();
	}

	void playerMove()
	{
		//CONTROLS
		playerMoveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && playerIsGrounded)
		{
			playerJump();
		}

		//ANIMATIONS
		//PLAYER DIRECTIONS
		if (playerMoveX < 0.0f && !facingRight)
		{
			playerFlip();
		}
		else if (playerMoveX > 0.0f &&  facingRight)
		{
			playerFlip();
		}

		//PHYSICS
		playerRigidBody2D.velocity = new Vector2(playerMoveX * playerSpeed, playerRigidBody2D.velocity.y);
	}

	void playerJump()
	{
		//JUMP
		playerRigidBody2D.AddForce(Vector2.up * playerJumpHeight);
		playerIsGrounded = false;

	}

	void playerFlip()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;

		localScale.x *= -1;
		transform.localScale = localScale;
	}


	void playerRayCast()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

		if(hit.distance < bounceOnEnemy && hit.collider.tag == "Enemy" )
		{
			playerRigidBody2D.AddForce(Vector2.up * 50);
			playerScoreAdd.playerScore += enemyScore.enemyPoints;
			Destroy(hit.collider.gameObject); //Change to change sprite to pixelated shit when broke
			
			
			
		}
		if (hit.distance < bounceOnEnemy && hit.collider.tag != "Enemy")
		{
			playerIsGrounded = true;
		}
	}
}
