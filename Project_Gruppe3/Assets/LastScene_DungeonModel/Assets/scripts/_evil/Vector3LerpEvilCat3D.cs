using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Vector3LerpEvilCat3D : MonoBehaviour
{
	float lerpTime = 1f;
	float currentLerpTime;
	List<Vector3> positionsList = new List<Vector3> ();
	
	Vector3 newPositionFromList;
	
	Vector3 startPos;
	Vector3 endPos;
	
	protected void Start() {
		AddVectorsToList ();
		startPos = transform.position;
		endPos = calculatePositionFromList();
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
		
		var newPosition = Vector3.Lerp (startPos, endPos, perc);
		transform.position = newPosition;
		
	}
	
	void UpdatePositionAfterShooting ()
	{
		currentLerpTime = 0f;
		startPos = transform.position;
		float ypsilon = startPos.y;
		newPositionFromList = calculatePositionFromList ();
		if (newPositionFromList.y == ypsilon) {
			endPos = startPos;
		}
		else {
			endPos = newPositionFromList;
		}	
	}
	
	void IncrementTimer ()
	{
		//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}
	}
	
	void AddVectorsToList ()
	{
		positionsList.Add (new Vector3(0.0f, 0.0f, 0.0f));
		positionsList.Add (new Vector3(3.0f, 4.0f, 0.0f));
		positionsList.Add (new Vector3(-1.0f, 6.0f, 0.0f));
		positionsList.Add (new Vector3(0.0f, 9.0f, 0.0f));
		positionsList.Add (new Vector3(1.0f, 14.0f, 0.0f));
		positionsList.Add (new Vector3(-2.0f, 18.0f, 0.0f));
		positionsList.Add (new Vector3(1.0f, 20.0f, 0.0f));
		positionsList.Add (new Vector3(-3.0f, 23.0f, 0.0f));
	}
	
	Vector3 calculatePositionFromList () {
		var rand = new System.Random();
		int index = rand.Next(positionsList.Count);
		Vector3 pos = positionsList [index];
		return pos;
	}
}