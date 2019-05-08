using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private LineRenderer lRenderer;
    public GameObject rendererCollider;

    public Text finalScore;
    private static int finalScoreInt;




    
    // Start is called before the first frame update
    void Start()
    {
        lRenderer = GetComponent<LineRenderer>();
        
        //finalScore.text = "Your Score: " + PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        finalScoreInt = GameController.punchCount;
        finalScore.text = "Your Score: " + finalScoreInt;
    }

    private void OnTriggerStay(Collider other)
    {
        RaycastHit hit;
        
        if (other.gameObject.CompareTag("single") && Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                GameController.punchCount = 0;
                SceneManager.LoadScene(3);
            }
        }
        
        else if (other.gameObject.CompareTag("double") && Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                GameController.punchCount = 0;
                SceneManager.LoadScene(4);
            }
        }

        else if (other.gameObject.CompareTag("home") && Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                SceneManager.LoadScene(0);
            }
        } 
        
    }
}

