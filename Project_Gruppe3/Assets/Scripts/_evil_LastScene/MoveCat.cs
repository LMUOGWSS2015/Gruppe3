using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCat : MonoBehaviour {

	float lerpTime = 1f;
	float currentLerpTime;
	List<Vector3> positionsList = new List<Vector3> ();
	Vector3 newPositionFromList;
	Vector3 startPos;
	Vector3 endPos;

	bool hasMoved = false;

	public bool HasMoved {
		get {
			return hasMoved;
		}
		set {
			hasMoved = value;
		}
	}
	
	public void MoveCatToNewPosition (EvilBasicFire fire)
	{
		IncrementTimer ();		
		//lerp!
		float perc = currentLerpTime / lerpTime;
		
		var newPosition = Vector3.Lerp (startPos, endPos, perc);
		transform.position = newPosition;		

		if (transform.position == newPosition && !fire.HasShot) {
			fire.ShootAtPlayer ();
			fire.HasShot = true;
			hasMoved = false;
		}
	}
	
	public void CalculateNewPosition ()
	{
		hasMoved = true;
		currentLerpTime = 0f;
		startPos = transform.position;
		newPositionFromList = CalculatePositionFromList ();
		if (newPositionFromList == startPos) {
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
	
	public void AddVectorsToList ()
	{
		var ladder = GameObject.Find ("Quad_Ladder").transform.position;
		positionsList.Add (new Vector3(ladder.x, ladder.y + 1.17f, ladder.z)); // Ladder
		
		var hay = GameObject.Find ("Hay_B").transform.position;
		positionsList.Add (new Vector3(hay.x, hay.y + 1.17f, hay.z)); //Hay
		
		var table = GameObject.Find ("Plane_Table").transform.position;
		positionsList.Add (new Vector3(table.x, table.y + 1.17f, table.z)); // Table
		
		var barrel = GameObject.Find ("Plane_Barrel").transform.position;
		positionsList.Add (new Vector3(barrel.x, barrel.y + 1.17f, barrel.z)); // Barrel
		
		var floorCage = GameObject.Find ("Quad_FloorCage").transform.position;
		positionsList.Add (new Vector3(floorCage.x, floorCage.y + 1.17f, floorCage.z)); // FloorCage
		
		var pillarD1 = GameObject.Find ("Quad_PillarD1").transform.position;
		positionsList.Add (new Vector3(pillarD1.x, pillarD1.y + 1.17f, pillarD1.z)); // Pillar Back-Front
		
		var pillarD2 = GameObject.Find ("Quad_PillarD2").transform.position;
		positionsList.Add (new Vector3(pillarD2.x, pillarD2.y + 1.17f, pillarD2.z)); // Pillar Back-Back
		
		var pillarD = GameObject.Find ("Quad_PillarD").transform.position;
		positionsList.Add (new Vector3(pillarD.x, pillarD.y + 1.17f, pillarD.z)); // Pillar Front-Back
	}
	
	Vector3 CalculatePositionFromList () {
		var rand = new System.Random();
		int index = rand.Next(positionsList.Count);
		Vector3 pos = positionsList [index];
		return pos;
	}
}
