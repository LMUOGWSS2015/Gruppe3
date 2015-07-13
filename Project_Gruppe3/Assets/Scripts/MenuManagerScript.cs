using UnityEngine;
using System.Collections;

public class MenuManagerScript : MonoBehaviour {

	public static bool isEyetrackingOn;

	EyeTrackingToggler eyeTrackingToggler;

	public void StartGame(){
		this.gameObject.AddComponent<EyeTrackingToggler>();
		eyeTrackingToggler = this.GetComponent<EyeTrackingToggler>();

		eyeTrackingToggler.CheckEyetrackingToggle ();
		isEyetrackingOn = EyeTrackingToggler.ToggleEyetracking;
		if (isEyetrackingOn) {
			Debug.Log ("Eyetracking is ON");
		} else {
			Debug.Log ("Eyetracking is OFF");
		}

		Application.LoadLevel("Level1");
		HoldInformations.SetLife (10);
	} 
}
