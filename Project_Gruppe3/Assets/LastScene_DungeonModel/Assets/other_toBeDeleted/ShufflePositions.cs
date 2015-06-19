using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class ShufflePositions : MonoBehaviour {

	List<Vector2> positionsFloatList = new List<Vector2> ();

	public bool isAlive = true;

	public float floatStrength = 1f;

	public float waitFor = 5;


	// Use this for initialization
	void Start () {
		AddFloatsToList ();
	}

	void AddFloatsToList ()
	{
		positionsFloatList.Add (new Vector2(0.0f, 0.0f));
		positionsFloatList.Add (new Vector2(0.0f, 3.0f));
        positionsFloatList.Add (new Vector2(0.0f, 7.0f));
	    positionsFloatList.Add (new Vector2(0.0f, 10.0f));
		positionsFloatList.Add (new Vector2(0.0f, 13.0f));
	    positionsFloatList.Add (new Vector2(0.0f, 17.0f));
	    positionsFloatList.Add (new Vector2(0.0f, 19.0f));
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("JumpBetweenPositions");
	}

	IEnumerator JumpBetweenPositions() {
		var rand = new System.Random();
		int index = rand.Next(positionsFloatList.Count);
		Debug.Log (index);

		Vector2 pos = positionsFloatList [index];
		Debug.Log (pos.x + "," + pos.y);

		transform.position = Vector2.Lerp(transform.position, pos, floatStrength * Time.deltaTime);            
	
		//this.originalY = this.transform.position.y;
		StartCoroutine (TakeABreak ());
		

		yield return null;
		//isAlive--;
		//JumpBetweenPositions (shuffledList);
	}

	IEnumerator TakeABreak() {
		//Debug.Log("Before Waiting 5 seconds");
		yield return new WaitForSeconds(waitFor);
		//Debug.Log("After Waiting 5 Seconds");
	}


}
