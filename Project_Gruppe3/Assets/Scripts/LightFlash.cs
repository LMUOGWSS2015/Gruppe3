using UnityEngine;
using System.Collections;
using iView;

public class LightFlash : GazeMonobehaviour{
	public float offsetDistanceGaze =10.0f;
	public float offsetDistanceMouse =0.25f;

	int calibrationType = 1;

	void Start()
	{
		Cursor.visible = false;
		// Start a calibration
		SMIGazeController.Instance.StartCalibration(calibrationType);
		// Start a validation
		//SMIGazeController.Instance.StartValidation();
	}
	
	
	
	void Update () {
		if(ToogleEyetracking.toggleEyetracking == false){
			mouse (offsetDistanceMouse);
		}
		else eyetracker (offsetDistanceGaze);
		
	}
	public void mouse (float offsetDistance){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit)){
			transform.position = hit.point + hit.normal * offsetDistance;
			
		}
	}

	public void eyetracker (float offsetDistance){
		Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		Ray ray = Camera.main.ScreenPointToRay(gazePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit)){
			transform.position = hit.point + hit.normal * offsetDistance;
			
		}
	}
	
	
}