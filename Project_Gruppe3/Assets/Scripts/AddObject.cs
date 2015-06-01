using UnityEngine;
using System.Collections;


public class AddObject : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	
	public GameObject[] objectArray;
	public GameObject randomObject;
	public float timeLimit;
	public Vector3[] positions;
	public bool[] inUse;
	public int maxAttempt = 9;
	
	void Start () {

		timeLimit = 10.0f;
		positions = new [] { new Vector3(7f,6f,-2f), new Vector3(7f,-6f,-2f),new Vector3(0f,6f,-2f),new Vector3(0f,-6f,-2f),new Vector3(-7f,6f,-2f),
			new Vector3(-7f,-6f,-2f),new Vector3(7f,0f,-2f),new Vector3(0f,0f,-2f),new Vector3(-7f,0f,-2f) };
		objectArray = new GameObject[4];
		inUse = new bool[9];
	

		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = GetPosition ();
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = GetPosition ();
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = GetPosition ();
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.position = GetPosition ();
		objectArray[0]= cube;
		objectArray[1]= sphere;
		objectArray[2]= capsule;
		objectArray[3]= cylinder;
		randomObject = objectArray[Random.Range(0,objectArray.Length)];
		Debug.Log ("Finde:" + randomObject);

	}
	
	// Update is called once per frame
	void Update () {
		//Licht trifft auf Objekt + Ist es das gesuchte Objekt ? + Zeit ist noch nicht abgelaufen
		if (randomObject.name == GetLightedGameObject() && (timeLimit > 0)) {

			Debug.Log ("Gewonnen!!");

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

	//Method: Get the Object which is clicked
	string GetLightedGameObject(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{	
				return hit.collider.name;
		
		}
		else
			return null;
		
		
	}

	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		if (timeLimit > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timeLimit);
		} else {
			GUI.Label(new Rect(125, 25, 100, 100), "Time is up!");
		}
	}
}
