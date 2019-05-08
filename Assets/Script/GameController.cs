using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public PunchPointGenerator punchGenerator;

	public enum TriggerColor { Red, Blue }

	public TriggerColor triggerColor;

	//public ScoreManager score;

	public static int punchCount = 0;

	public Text punchScore;

	public static int failedAttempt = 0;
	//public int numberOfFailedAttempt;
	public bool failed;

	public EndGame gameEnd;


	// Use this for initialization
	void Start ()
	{
		failedAttempt = 0;
		
	}
	

	void OnTriggerEnter(Collider enterCollider)
	{
		if (triggerColor == TriggerColor.Red)
		{
			if ((OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
			    && (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
			    && (OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger)))
			{
				if (enterCollider.gameObject.CompareTag("redPunch"))

				{
					AddScore();

					Debug.Log("RedEnter");
					Debug.Log(Mathf.CeilToInt(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude) + " is the velocity of the left controller");

					punchGenerator.GenerateNextPoint();

				}
				else if (enterCollider.gameObject.CompareTag("bluePunch"))
				{
					//Failed();
					DeductScore();
                  
					Debug.Log("You have failed " + failedAttempt + " times");
				}
			}
		}
		else if (triggerColor == TriggerColor.Blue)
		{
			if ((OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
			    && (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
			    && (OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger)))
			{
				if (enterCollider.gameObject.CompareTag("bluePunch"))
				{
                    AddScore();

					Debug.Log("BlueEnter");
					Debug.Log(Mathf.CeilToInt(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude) + " is the velocity of the right controller");

					punchGenerator.GenerateNextPoint();

				}

				else if (enterCollider.gameObject.CompareTag("redPunch"))
				{
					//Failed();
					DeductScore();
                   	
					Debug.Log("You have failed " + failedAttempt + " times");
				}
			}
		}

	}


	private void AddScore()
	{
		punchCount += Mathf.CeilToInt(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude) * 25;
		punchScore.text = "Score: " + punchCount;
	}

	private void DeductScore()
	{
		punchCount -= Mathf.CeilToInt(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude) * 25;
		punchScore.text = "Score: " + punchCount;
		failedAttempt++;
	}


	/*public void Failed()
	{
		if (failedAttempt == 5)
		{
			failed = true;
			gameEnd.LevelFailed();
		}
	}*/

	private void OnDisable()
	{
		//PlayerPrefs.SetInt("score", punchCount);
	}
}
