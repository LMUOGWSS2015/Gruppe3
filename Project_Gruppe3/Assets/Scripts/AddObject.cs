using UnityEngine;
using System.Collections;


public class AddObject : MonoBehaviour {
	
	public GameObject[] objectArray;
	public GameObject randomObject;
	public float timeLimit;
	

	void Start () {

		timeLimit = 10.0f;

		objectArray = new GameObject[4];
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0.5F, 0);
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = new Vector3(0, 1.5F, 0);
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = new Vector3(2, 1, 0);
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.position = new Vector3(-2, 1, 0);
		objectArray[0]= cube;
		objectArray[1]= sphere;
		objectArray[2]= capsule;
		objectArray[3]= cylinder;
		randomObject = objectArray[Random.Range(0,objectArray.Length)];
		Debug.Log (randomObject);

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown (0) && randomObject.name == GetClickedGameObject().name && (timeLimit > 1)){

			Debug.Log ("Gewonnen!!" + timeLimit);

		}
		else if((timeLimit < 1)){
			Debug.Log("Verloren :(");
			
		}
		else {
			timeLimit -= Time.deltaTime;
			Debug.Log (timeLimit);

		}

		
		
		
	}
	
	//Method: Get the Object which is clicked
	GameObject GetClickedGameObject(){

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		if (Physics.Raycast(ray, out hit))
			return hit.transform.gameObject;
		else
			return null;
		
		
	}
}
