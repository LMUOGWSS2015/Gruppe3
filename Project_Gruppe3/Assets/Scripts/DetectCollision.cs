using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
	public float timelimitLevel = 20.0f;

	// Update is called once per frame
	void Update () {

		this.timelimitLevel -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){
	
		//detect collision with target
		if (col.gameObject.name == "Target" && (timelimitLevel  > 0)) {
			//destroy target-wall
			Destroy(col.gameObject); 

			//TODO
			//load new scene
			//Application.LoadLevel(sceneName);
		}
		//TODO
		//detect collision with cats
		else if (col.gameObject.name == "Cats") {
			//reset scene#
			ResetScene(); 
			//TODO
			//life -1
		}
	}

	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		if (timelimitLevel  > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timelimitLevel );
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
