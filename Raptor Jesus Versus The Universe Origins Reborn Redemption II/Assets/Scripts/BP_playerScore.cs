using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BP_playerScore : MonoBehaviour {

	public int playerScore = 0;
	public int playerHealth;
	public GameObject playerScoreUI;
	public GameObject playerHealthUI;

	// Use this for initialization
	void Start () {
		playerHealth = gameObject.GetComponent<BP_playerHealth>().health;
	}
	
	// Update is called once per frame
	void Update () {
		playerScoreUI.GetComponent<Text>().text = ("Score: " + (int)playerScore);
		playerHealthUI.GetComponent<Text>().text = ("Score: " + (int)playerHealth);
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "End Level")
		{
			countScore();
		}
		if (trigger.gameObject.tag == "Coin")
		{
			playerScore += 10;
			Destroy(trigger.gameObject);
		}
		//Load end of levels scene
	}

	void countScore()
	{

	}
}
