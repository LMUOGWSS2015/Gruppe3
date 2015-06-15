using UnityEngine;
using System.Collections;
using iView;

public class LightFlash : GazeMonobehaviour{
	public float distance = 10.0f;
	public float offsetDistance =10.0f;
	
	int calibrationType = 3;

	void Start()
	{
		Cursor.visible = false;
		// Start a calibration
		//SMIGazeController.Instance.StartCalibration(calibrationType);
		// Start a validation
		//SMIGazeController.Instance.StartValidation();
	}
	
	
	
	void Update () {
	

		//Maus
		/*Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = distance + 12;
		transform.position = Camera.main.ScreenPointToRay(mousePosition);*/
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit)){
			transform.position = hit.point + hit.normal * offsetDistance;

		}

		/*Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		gazePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint(gazePosition);
		//Debug.Log("Gaze Position: " + gazePosition);*/

		/*NEW GAZE*/

/*
		Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		Ray ray = Camera.main.ScreenPointToRay(gazePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit)){
			transform.position = hit.point + hit.normal * offsetDistance;

		}
*/		 
		
	}
	
	
}