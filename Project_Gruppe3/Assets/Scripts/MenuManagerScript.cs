using UnityEngine;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public static bool eyetrackingOn;
	public void StartGame(){

		eyetrackingOn = true;
			//ToogleEyetracking.toggleEyetracking;
		Application.LoadLevel("Level1");
		HoldInformations.SetLife (3);
	}

 
}
