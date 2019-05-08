using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchFeedback : MonoBehaviour
{

	public AudioClip clipSound;
	//public AudioSource audio;
	

	// Use this for initialization
	void Start ()
	{
		
	}
	
	void OnCollisionEnter(Collision controller)
	{
		
		float rightController = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude;
		float leftController = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude;

		if (controller.gameObject.CompareTag("oculusTouchRight"))
		{
			AudioSource.PlayClipAtPoint(clipSound, transform.position, rightController/2);
			//audio.Play();
			//OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
			OVRInput.SetControllerVibration(.15f * rightController, .04f * rightController, OVRInput.Controller.RTouch);
		}
		
		else if (controller.gameObject.CompareTag("oculusTouchLeft"))
		{
			AudioSource.PlayClipAtPoint(clipSound, transform.position, leftController/2);
	       // audio.Play();
	        //OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
        	OVRInput.SetControllerVibration(.15f * leftController, .04f * leftController, OVRInput.Controller.LTouch);
        }
		
	}

}
