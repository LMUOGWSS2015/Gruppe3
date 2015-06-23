using UnityEngine;
using System.Collections;
using iView;

public class Katapult : GazeMonobehaviour {
	Rigidbody dogRB;
	
	// Use this for initialization
	void Start () {
		dogRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		jump ();

	}
	//Eyetracking
	public void jump (){
		if (Input.GetKeyDown (KeyCode.Space)) {
			dogRB.AddForce (Vector3.forward * 300);
			dogRB.useGravity = false;
		}
	}



}
