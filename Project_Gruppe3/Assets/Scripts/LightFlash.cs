using UnityEngine;
using System.Collections;
using iView;

public class LightFlash : GazeMonobehaviour{
	public float distance = 25.0f;
	public Vector3 center;
	//public static Vector3 lightPosition;
	
	
	void Start()
	{
		Cursor.visible = false;
	}
	
	
	
	void Update () {
	

		//Maus
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = distance + 12;
		transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		center = transform.position;


		/*Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		gazePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint(gazePosition);
		//Debug.Log("Gaze Position: " + gazePosition);*/

		
	}
	
	
}