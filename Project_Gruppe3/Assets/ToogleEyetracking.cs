using UnityEngine;
using System.Collections;

public class ToogleEyetracking : MonoBehaviour {

	public static bool toggleEyetracking = true;

	void OnGUI() {
	
		toggleEyetracking = GUI.Toggle(new Rect(10, 50, 150, 50), toggleEyetracking, "Eyetracking an?");


	}


}
