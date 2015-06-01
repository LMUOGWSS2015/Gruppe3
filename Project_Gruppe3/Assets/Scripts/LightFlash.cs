using UnityEngine;
using System.Collections;
using iView;

public class LightFlash : GazeMonobehaviour{
	public float distance = 25.0f;
	//public static Vector3 lightPosition;
	
	
	void Start()
	{
		
	}
	
	
	
	void Update () {
		/*
		//Maus
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint (mousePosition);
		Debug.Log("Mouse Position: " + mousePosition);
		
		*/

		Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		gazePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint(gazePosition);
		Debug.Log("Gaze Position: " + gazePosition);

		
	}
	
	
}