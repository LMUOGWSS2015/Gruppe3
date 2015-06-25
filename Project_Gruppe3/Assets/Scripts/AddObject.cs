﻿using UnityEngine;
using System.Collections;
using iView;


public class AddObject : GazeMonobehaviour {

	Ray ray;
	RaycastHit hit;
	
	public GameObject[] objectArray;
	public GameObject randomObject;
	public float timeLimit;
	public Vector3[] positions;
	public bool[] inUse;
	public int maxAttempt = 9;
	private int currentScale = 2; 
	public Vector3 gazePosition;
	public bool timeMouseOverBool= false;
	public float timeMouseOver= 0.0f;


	void Start () {

		timeLimit = 30.0f;

		//Definition of object position
		positions = new [] { new Vector3(-7f,15f,10f), new Vector3(0f,12f,10f),new Vector3(6f,14f,10f),new Vector3(-6f,8f,10f),new Vector3(0f,7f,10f),
			new Vector3(8f,7f,10f),new Vector3(-8f,1f,10f),new Vector3(-1f,0f,10f),new Vector3(6f,2f,10f) };
		objectArray = new GameObject[9];
		inUse = new bool[9];
	
		//Adding objects
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.transform.position = GetPosition ();
		cube1.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube1.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.position = GetPosition ();
		cube2.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube2.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube3.transform.position = GetPosition ();
		cube3.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube3.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube4.transform.position = GetPosition ();
		cube4.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube4.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube5 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube5.transform.position = GetPosition ();
		cube5.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube5.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube6 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube6.transform.position = GetPosition ();
		cube6.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube6.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube7 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube7.transform.position = GetPosition ();
		cube7.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube7.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube8.transform.position = GetPosition ();
		cube8.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube8.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		GameObject cube9 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube9.transform.position = GetPosition ();
		cube9.transform.parent = GameObject.Find ("Search Objects").transform; 
		cube9.transform.localScale = new Vector3 (currentScale, currentScale, 0.01f); 

		//Adding objects to array
		objectArray[0]= cube1;
		objectArray[1]= cube2;
		objectArray[2]= cube3;
		objectArray[3]= cube4;
		objectArray[4]= cube5;
		objectArray[5]= cube6;
		objectArray[6]= cube7;
		objectArray[7]= cube8;
		objectArray[8]= cube9;

		//Creating random objects
		randomObject = objectArray[Random.Range(0,objectArray.Length)];
		Debug.Log ("Finde:" + randomObject);


	}
	
	// Update is called once per frame
	void Update () {
		mouseOverTimer ();
		gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		//Licht trifft auf Objekt + Ist es das gesuchte Objekt ? + Zeit ist noch nicht abgelaufen
		if (randomObject.name == GetLightedGameObjectMouse() && (timeLimit > 0) && timeMouseOverBool) {

			Debug.Log ("Gewonnen!!");
			//back to main game
			Application.LoadLevel ("Level1");

			GameObject.FindGameObjectWithTag("pug").GetComponent<PugLife>().IncreaseLife();

		}
		else if(randomObject.name == GetLightedGameObjectEyes() && (timeLimit >0) && timeMouseOverBool){

			Debug.Log ("Gewonnen!!");
			//back to main game
			Application.LoadLevel ("Level1");
			GameObject.FindGameObjectWithTag("pug").GetComponent<PugLife>().IncreaseLife();

		}
		else {
			timeLimit -= Time.deltaTime;


		}

	}

	//random Vergabe der Positionen :)
	Vector3 GetPosition(){

		int attempt = 0;
		int index = 0;

		do
		{	
			index =  Random.Range(0,positions.Length);

	

		}
		while(inUse[index] && ++attempt < maxAttempt);

		inUse[index] = true;
		return positions[index];
		
	}

	//Method: Get the Object which is hovered
	string GetLightedGameObjectMouse(){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			foreach (GameObject obj in objectArray) {
				//TODO Zeitintervall
				if (Vector3.Distance (hit.point, obj.transform.position) < 1.1) {
					return hit.collider.name;
				}
			}
			return null;
		} else
			return null;
		
	}

	//Method: Get the Object which is checked by eye
	string GetLightedGameObjectEyes(){
		ray = Camera.main.ScreenPointToRay (gazePosition);
		if (Physics.Raycast (ray, out hit)) {
			foreach (GameObject obj in objectArray) {
				
				if (Vector3.Distance (hit.point, obj.transform.position) < 1.1) {
					return hit.collider.name;
				}
			}
			return null;
		} else
			return null;
		
	}

	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		if (timeLimit > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timeLimit);
		} else {
			GUI.Label(new Rect(125, 25, 100, 100), "Time is up!");
			//back to main game
			//Application.LoadLevel ("Level1");
		}
		GUI.Label (new Rect (125, 150, 500, 100), "Finde: " + randomObject.name);

	}

	//check if mouseOver was long enough
	void mouseOverTimer()
	{
		if(randomObject.name == GetLightedGameObjectMouse()!=null)
		{
			timeMouseOver = Time.time;
			Debug.Log("randomObject.name: " +randomObject.name+ " GetLightedGameObjectMouse: " + GetLightedGameObjectMouse());
			Debug.Log("MouseOver since : " + timeMouseOver + " Seconds");
		}
		if(randomObject.name != GetLightedGameObjectMouse())
		{
			timeMouseOver = 0.0f;
			Debug.Log("MouseOver since : " + timeMouseOver + " Seconds");
		}

		if(Time.time - timeMouseOver >= 5.0f)
		{
			timeMouseOverBool = true;
		}

	}
}
