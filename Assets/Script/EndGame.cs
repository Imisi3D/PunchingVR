using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {


	public float timeRemaining = 90.0f;
	public int targetScore;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeRemaining -= Time.deltaTime;

		if ((timeRemaining <= 0) && (GameController.punchCount >= targetScore))
		{
			Debug.Log("you win called");
			YouWin();
		}
		else if (((timeRemaining <= 0) && (GameController.punchCount < targetScore)) || GameController.failedAttempt == 5)
		{
			Debug.Log("you lose called");
			YouLose();
		}
	}

	
	public void YouWin()
	{
		SceneManager.LoadScene(1);
	}

	public void YouLose()
	{
		SceneManager.LoadScene(2);
	}

	public void RestartGame()
	{
		
	}

	public void StartAgain()
	{
		GameController.punchCount = 0;
		SceneManager.LoadScene(3);
	}
}
