using UnityEngine;
using System.Collections;
using iView;

public class Katapult : GazeMonobehaviour {
	Rigidbody dogRB;
	Rigidbody catapultArmRB;
	float rotationSpeedMouse = 3f;
	float rotationSpeedEyes = 0.01f;
	GameObject dog;
	GameObject catapultArm;
	GameObject catapult;
	Animator startCatapult;
	Animator startDogFly;


	// Use this for initialization
	void Start () {
		dog = GameObject.Find ("NovaPugCatapultScene"); 
		dogRB = dog.GetComponent<Rigidbody>(); 
		startDogFly = dog.GetComponent<Animator>();

		catapultArm = GameObject.Find ("Catapuly/CatapultHeadHolder"); 
		catapultArmRB = catapultArm.GetComponent<Rigidbody>(); 

		catapult = GameObject.Find ("Catapuly"); 
		startCatapult = catapult.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		rotateMouse ();
		jump ();

	}
	//Eyetracking
	public void jump (){
		if (Input.GetKeyDown (KeyCode.Space)) {
			startCatapult.SetTrigger("JumpTrigger");
			startDogFly.SetTrigger("FlyTrigger");
			//dogRB.AddForce (transform.forward * 400);
			Debug.Log("JUMP");
			dogRB.useGravity = false;
		}
	}

	public void rotateMouse (){
		dogRB.rotation = Quaternion.Euler(dogRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedMouse* Input.GetAxis ("Mouse X"), 0f));
	//	catapultArm.transform.Rotate= Quaternion.Euler(catapultArmRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedMouse* Input.GetAxis ("Mouse X"), 0f));
		//catapultArmRB.rotation = Quaternion.Euler(catapultArmRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedMouse* Input.GetAxis ("Mouse X"), 0f));
	}
	//Eyetracking
	public void rotateEyes (){
		Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		dogRB.rotation = Quaternion.Euler(dogRB.rotation.eulerAngles + new Vector3(0f, rotationSpeedEyes* gazePosition.x, 0f));
	}

}
