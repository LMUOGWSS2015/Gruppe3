using UnityEngine;
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
	public int maxAttempt = 10;
	private int currentScale = 2; 
	public Vector3 gazePosition;
	public bool timeMouseOverBool= false;
	public float timeMouseOver= 0.0f;


	void Start () {

		timeLimit = 30.0f;

		//Definition of object position
		ppositions = new [] { new Vector3(-7f,14f,12f), new Vector3(0f,14f,12f),new Vector3(7f,14f,12f),new Vector3(-7f,8f,12f),new Vector3(0f,8f,12f),
			new Vector3(7f,8f,12f),new Vector3(-7f,2f,12f),new Vector3(0f,2f,12f),new Vector3(7f,4f,12f), new Vector3(1f,-1f,12f) };			objectArray = new GameObject[10];
		inUse = new bool[10];
	
		//Adding objects
		GameObject alien = GameObject.Find ("alien");
		alien.transform.position = GetPosition ();
		
		GameObject apple = GameObject.Find ("apple");
		apple.transform.position = GetPosition ();
		
		GameObject bear = GameObject.Find ("bear");
		bear.transform.position = GetPosition ();
		
		GameObject car = GameObject.Find ("car");
		car.transform.position = GetPosition ();
		
		GameObject dolly = GameObject.Find ("dolly");
		dolly.transform.position = GetPosition ();
		
		GameObject gift = GameObject.Find ("gift");
		gift.transform.position = GetPosition ();
		
		GameObject giraffe = GameObject.Find ("giraffe");
		giraffe.transform.position = GetPosition ();
		
		GameObject star = GameObject.Find ("star");
		star.transform.position = GetPosition (); 
		
		GameObject penguin = GameObject.Find ("pengiun");
		penguin.transform.position = GetPosition ();
		
		GameObject pumpkin = GameObject.Find ("pumpkin");
		pumpkin.transform.position = GetPosition ();
		
		//Adding objects to array

		objectArray[0]= alien;
		objectArray[1]= apple;
		objectArray[2]= bear;
		objectArray[3]= car;
		objectArray[4]= dolly;
		objectArray[5]= gift;
		objectArray[6]= giraffe;
		objectArray[7]= star;
		objectArray[8]= penguin;
		objectArray[9]= pumpkin;
		

		//Creating random objects
		randomObject = objectArray[Random.Range(0,objectArray.Length)];
		Debug.Log ("Finde:" + randomObject);


	}
	
	// Update is called once per frame
	void Update () {
		mouseOverTimer ();
		gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		//Licht trifft auf Objekt + Ist es das gesuchte Objekt ? + Zeit ist noch nicht abgelaufen
		//BG: timeMouseOverBool deleted
		if (randomObject.name == GetLightedGameObjectMouse() && (timeLimit > 0)) {

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
					//BG: hit.collider.name replaced with obj.transform.name 
					return obj.transform.name;
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
