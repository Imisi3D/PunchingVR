using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPointGenerator : MonoBehaviour {

	public List<GameObject> punchPoints;
	public int currentPoint = 0;

	public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(TimeUp());
	}

	public void GenerateNextPoint()
	{

		int itemIndex = Random.Range(0, punchPoints.Count - 1);

		punchPoints[currentPoint].SetActive(false);
		punchPoints[itemIndex].SetActive(true);

		currentPoint = itemIndex;

	}

	IEnumerator TimeUp()
	{
		int point = currentPoint;
		yield return new WaitForSeconds(timer);
		if (point == currentPoint)
			GenerateNextPoint();
	}
}
