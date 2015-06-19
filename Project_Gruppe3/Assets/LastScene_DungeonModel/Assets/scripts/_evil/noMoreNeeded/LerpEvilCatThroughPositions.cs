using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LerpEvilCatThroughPositions : MonoBehaviour
{
	float lerpTime = 1f;
	float currentLerpTime;
	List<float> positionsList = new List<float> ();

	float moveDistance;
	float newPositionFromList;
	
	Vector2 startPos;
	Vector2 endPos;
	
	protected void Start() {
		AddFloatsToList ();
		moveDistance = calculatePositionFromList ();
		startPos = transform.position;
		endPos = transform.position + transform.up * moveDistance;
	}
	
	protected void Update() {
		//reset when we press spacebar
		// after shooting - insert FireHairBall in here!
		if (Input.GetKeyDown(KeyCode.Space)) {
			UpdatePositionAfterShooting ();
		}

		IncrementTimer ();
		
		//lerp!
		float perc = currentLerpTime / lerpTime;
		transform.position = Vector2.Lerp(startPos, endPos, perc);
	}

	void UpdatePositionAfterShooting ()
	{
		currentLerpTime = 0f;
		startPos = transform.position;
		float ypsilon = startPos.y;
		newPositionFromList = calculatePositionFromList ();
		if (newPositionFromList == ypsilon) {
			moveDistance = 0;
		}
		else {
			//moveDistance -= newPositionFromList;
			moveDistance = newPositionFromList - ypsilon;
			Debug.Log ("MoveDistance is " + moveDistance);
		}
		endPos = transform.position + transform.up * moveDistance;
	}

	void IncrementTimer ()
	{
		//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}
	}

	void AddFloatsToList ()
	{
		positionsList.Add (0.0f);
		positionsList.Add (3.0f);
		positionsList.Add (7.0f);
		positionsList.Add (10.0f);
		positionsList.Add (13.0f);
		positionsList.Add (17.0f);
		positionsList.Add (19.0f);
	}
	
	float calculatePositionFromList () {
		var rand = new System.Random();
		int index = rand.Next(positionsList.Count);
		float pos = positionsList [index];
		Debug.Log (pos);
		return pos;
	}
}