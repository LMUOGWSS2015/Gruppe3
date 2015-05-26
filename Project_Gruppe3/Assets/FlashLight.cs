using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	public float distance = 10.0f;

	void Start()
	{

		//light1 = GetComponentInChildren<Light>();
		//light1.enabled = false;
	}
/*
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
			on = !on;
		if(on)
			light1.enabled = true;
		else if(!on)
			light1.enabled = false;
	}
	*/


	void Update () {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = distance;
		transform.position = Camera.main.ScreenToWorldPoint (mousePosition);
	}


}