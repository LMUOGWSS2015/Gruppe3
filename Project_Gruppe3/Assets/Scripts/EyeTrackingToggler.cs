using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EyeTrackingToggler : MonoBehaviour {

	public static bool toggleEyetracking;

	GameObject eyeTrackingToggler;
	
	public void CheckEyetrackingToggle() {
		eyeTrackingToggler = GameObject.FindGameObjectWithTag ("ToogleEyetracking");
		Toggle toggle = eyeTrackingToggler.GetComponent<Toggle> ();
		if (toggle.isOn) {
			toggleEyetracking = true;
		} else {
			toggleEyetracking = false;
		}
	}
	
	public static bool ToggleEyetracking {
		get {
			return toggleEyetracking;
		}
	}
}
