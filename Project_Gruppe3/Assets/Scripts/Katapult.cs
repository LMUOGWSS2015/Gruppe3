using UnityEngine;
using System.Collections;
using iView;

public class Katapult : GazeMonobehaviour {
	Rigidbody dogRB;
	float rotationSpeedMouse = 3f;
	float rotationSpeedEyes = 0.01f;

	// Use this for initialization
	void Start () {
		dogRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rotateMouse ();
		jump ();

	}
	//Eyetracking
	public void jump (){
		if (Input.GetKeyDown (KeyCode.Space)) {
			dogRB.AddForce (transform.forward * 300);
			dogRB.useGravity = false;
		}
	}

	public void rotateMouse (){
		dogRB.rotation = Quaternion.Euler(dogRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedMouse* Input.GetAxis ("Mouse X"), 0f));
	}
	//Eyetracking
	public void rotateEyes (){
		Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		dogRB.rotation = Quaternion.Euler(dogRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedEyes* gazePosition.x, 0f));
	}

}
