using UnityEngine;
using System.Collections;
using iView;
using UnityEngine.UI;


public class AddObject : GazeMonobehaviour {
	
	Ray ray;
	RaycastHit hit;

	public Vector3 temp;
	public GameObject[] objectArray;
	public GameObject randomObject;
	public float timeLimit;
	public Vector3[] positions;
	public bool[] inUse;
	public int maxAttempt = 10;
	private int currentScale = 2; 
	public Vector3 gazePosition;
	public int tempHoldInfo;
	public Font MyFont;
	public GameObject sound;
	public Text wonText;
	public bool hasPlayed = false; 
	public bool lostGame = true;
	public AudioSource audio;
	public static int count;

	
	void Start () {
		wonText.enabled = false;
		timeLimit = 10.0f;
		positions = new [] { new Vector3(-7f,14f,12f), new Vector3(0f,14f,12f),new Vector3(7f,14f,12f),
			new Vector3(-7f,8f,12f),new Vector3(0f,8f,12f),
			new Vector3(7f,8f,12f),new Vector3(-7f,2f,12f),new Vector3(0f,2f,12f),
			new Vector3(7f,4f,12f), new Vector3(1f,-1f,12f)};			
		objectArray = new GameObject[10];
		inUse = new bool[10];

		
		//Adding objects
		GameObject alien = GameObject.Find ("Alien");
		count = 0;
		alien.transform.position = GetPosition ();
		
		GameObject apple = GameObject.Find ("Apple");
		count++;
		apple.transform.position = GetPosition ();
		
		GameObject bear = GameObject.Find ("Bear");
		count++;
		bear.transform.position = GetPosition ();
		
		GameObject car = GameObject.Find ("Car");
		count++;
		car.transform.position = GetPosition ();

		GameObject dolly = GameObject.Find ("Dolly");
		count++;
		dolly.transform.position = GetPosition ();
		
		GameObject gift = GameObject.Find ("Gift");
		count++;
		gift.transform.position = GetPosition ();
		
		GameObject giraffe = GameObject.Find ("Giraffe");
		count++;
		giraffe.transform.position = GetPosition ();
		
		GameObject star = GameObject.Find ("Star");
		count++;
		star.transform.position = GetPosition (); 
		
		GameObject penguin = GameObject.Find ("Penguin");
		count++;
		penguin.transform.position = GetPosition ();
		
		GameObject pumpkin = GameObject.Find ("Pumpkin");
		count++;
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
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//mouseOverTimer ();
		gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		if (randomObject.name == GetLightedGameObjectMouse() && (timeLimit > 0)) {
			//back to main game
			wonText.enabled = true;

			if (hasPlayed == false)
			{	lostGame = false;
				hasPlayed = true;
				audio = sound.GetComponent<AudioSource>();
				audio.Play();
			}
			else
			{
				hasPlayed = true;
			}

			tempHoldInfo = HoldInformations.GetLife();
			tempHoldInfo = tempHoldInfo +1;
			HoldInformations.SetLife(tempHoldInfo);
		
		}
		else if(randomObject.name == GetLightedGameObjectEyes() && (timeLimit >0)){
			//back to main game

			if (hasPlayed == false)
			{	
				hasPlayed = true;
				lostGame = false;
				sound.GetComponent<AudioSource>().Play();
			}
			else
			{
				hasPlayed = true;
			}
			wonText.enabled = true;
			tempHoldInfo = HoldInformations.GetLife();
			tempHoldInfo = tempHoldInfo +1;
			HoldInformations.SetLife(tempHoldInfo);

			
		}
		else if(hasPlayed == true){
			if(!audio.isPlaying){
				Application.LoadLevel ("Level1");
			}

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

		if (count == 9) {
			for(int i = 0; i<inUse.Length; i++){
				if(inUse[i] == false){
					temp =  positions[i];
				}

			}
			return temp;

		} else {
			inUse [index] = true;
			return positions [index];
		}
	}
	//Method: Get the Object which is hovered
	string GetLightedGameObjectMouse(){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			foreach (GameObject obj in objectArray) {
				
				if (Vector3.Distance (hit.point, obj.transform.position) < 1.4) {
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
				
				if (Vector3.Distance (hit.point, obj.transform.position) < 1.4) {
					return hit.collider.name;
				}
			}
			return null;
		} else
			return null;
		
	}
	
	//Zeitdisplay in der GUI :) 
	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		GUI.skin.font = MyFont;
		
		if (timeLimit > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timeLimit);
	
		} 
		else {
			if(lostGame == true){
				GUI.Label(new Rect(125, 25, 100, 100), "Time is up!");
				GUI.Label (new Rect (300, 150, 600, 100), "<size=30>YOU LOST</size>");
				//back to main game
				Application.LoadLevel ("Level1");
			}

		}
		GUI.Label (new Rect (125, 150, 500, 100), "Find: " + randomObject.name);
		
		
	}
	
}
