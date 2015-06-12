using UnityEngine;
using System.Collections;
using iView;

public class LightFlash : GazeMonobehaviour{
	public float distance = 25.0f;
	public float offsetDistance = 0.25f;
	
	
	void Start()
	{
		Cursor.visible = false;

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
	
		/*RayCastHit hit;
		if (Physics.Raycast(ray, out hit, 100)) {
			Instantiate(item, hit.point, Quaternion.identity);
		}*/
		
		/*Vector3 gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		gazePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint(gazePosition);
		//Debug.Log("Gaze Position: " + gazePosition);*/

		
	}
	
	
}