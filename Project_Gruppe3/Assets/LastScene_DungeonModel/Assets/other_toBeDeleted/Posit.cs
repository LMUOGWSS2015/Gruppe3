using UnityEngine;
using System.Collections;

public class Posit : MonoBehaviour {
	public int maxSpeed = 3;
	
	private Vector3 startPosition;

	public float upperLimit = 10f;

	public float lowerLimit=0f;
	
	// Use this for initialization	
	void Start () 
	{
		
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveVertical ();
	}
	
	void MoveVertical()
	{
		transform.position = new Vector3(transform.position.x, startPosition.y + ((float) Mathf.Sin(Time.time * maxSpeed)), transform.position.z);
		

	}
}
