using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	public Light light1;  
	
	void Start()
	{
		light1.enabled = false;
	}
	
	public void ToggleFlashLight () 
	{
		
		if (light1.enabled == true) 
		{
			light1.enabled = false;
		}
		else
		{
			light1.enabled = true;
		}
	}
}