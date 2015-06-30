using UnityEngine;
using System.Collections;

public class BonusDoor : MonoBehaviour {

	#region Variables (private)
	
	private GameObject[] doorPoint;
	private int length;
	private int index;

	#endregion

	// Use this for initialization
	void Start () {
		if(doorPoint == null)
			doorPoint = GameObject.FindGameObjectsWithTag ("BonusDoor");

		length = doorPoint.Length;
		index = Random.Range (0, doorPoint.Length);
		Debug.Log ("doornumber " + index);
		doorPoint [index].GetComponent<MeshRenderer>().enabled = true;
	}
}
