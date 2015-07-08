using UnityEngine;
using System.Collections;
using iView

public class BonusDoor : GazeMonobehaviour {

	#region Variables (private)

	Ray rayGaze;
	RaycastHit hit;
	private GameObject[] doorPoint;
	private int length;
	private int index;
	public Vector3 gazePosition;


	#endregion

	// Use this for initialization
	void Start () {
		if(doorPoint == null)
			doorPoint = GameObject.FindGameObjectsWithTag ("BonusDooor");

		length = doorPoint.Length;
		index = Random.Range (0, doorPoint.Length);
		Debug.Log ("doornumber " + index);
		doorPoint [index].GetComponent<MeshRenderer>().enabled = true;
	}

	void Update(){
		gazePosition = SMIGazeController.Instance.GetSample ().averagedEye.gazePosInUnityScreenCoords ();
		rayGaze = Camera.main.ScreenPointToRay (gazePosition);

		if (Physics.Raycast (rayGaze, out hit)) {

			base.OnGazeEnter(hit);
		}
	}

	public override void OnGazeEnter(RaycastHit hitInformation){
	
		foreach(GameObject obj in doorPoint){
			
			if(hit.collider.gameObject.name == obj.transform.name){
				Debug.Log ("The doornumber is: " + hit.collider.gameObject.name);
				Application.LoadLevel("BonusLevelNew");

			}
		}
	}
}
