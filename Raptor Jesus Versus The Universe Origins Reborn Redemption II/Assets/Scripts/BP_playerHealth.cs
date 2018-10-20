using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BP_playerHealth : MonoBehaviour {

	public int health = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < -7)
		{
			//Player dies
			Debug.Log("Omae wa mo shindeiru");
			Die();
		}

		if(health == 0)
		{
			Die();
		}
	}

	void Die ()
	{
		SceneManager.LoadScene("Level_1");
	}
}
