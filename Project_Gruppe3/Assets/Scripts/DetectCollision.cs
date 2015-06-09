using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
	public float timeLimit = 10.0f;

	// Update is called once per frame
	void Update () {

		timeLimit -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){
	
		//detect collision with target
		if (col.gameObject.name == "Target" && (timeLimit > 0)) {
			//destroy target-wall
			Destroy(col.gameObject); 

			//TODO
			//load new scene
			//Application.LoadLevel(sceneName);
		}
		//TODO
		//detect collision with cats
		else if (col.gameObject.name == "Cats") {
			//reset scene
			ResetScene(); 
			//TODO
			//life -1
		}
	}

	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		if (timeLimit > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timeLimit);
		} else {
			GUI.Label(new Rect(125, 25, 100, 100), "Time is up!");
			ResetScene(); 
		}
	}

	//reset scene
	void ResetScene(){
	
		Application.LoadLevel(Application.loadedLevel);
	}
}
