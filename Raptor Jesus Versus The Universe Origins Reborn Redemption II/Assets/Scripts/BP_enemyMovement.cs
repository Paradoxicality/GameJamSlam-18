using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_enemyMovement : MonoBehaviour {

	public int enemySpeed = 3;
	public float reboundDistance = 0.7f;

	private bool facingRight = false;
	private int enemyMoveX;
	private Rigidbody2D enemyRigidBody2D;

	GameObject player;
	BP_playerHealth playerHealth;

	// Use this for initialization
	void Start () {
		enemyRigidBody2D = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<BP_playerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(enemyMoveX, 0));
		enemyRigidBody2D.velocity = new Vector2(enemyMoveX, 0) * enemySpeed;
		if (hit.distance < reboundDistance)
		{
			facingRight = !facingRight;
			flipEnemy();
			if(hit.collider.tag == "Player")
			{
				playerHealth.health--;

			}
			Debug.Log("FLIP");
		}
	}

	void flipEnemy()
	{
		Vector2 localScale = gameObject.transform.localScale;

		if (enemyMoveX > 0) 
		{
			enemyMoveX = -1;
			
		} else
		{
			enemyMoveX = 1;
		}

		localScale.x *= -1;
		transform.localScale = localScale;



	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);	
	}
}
