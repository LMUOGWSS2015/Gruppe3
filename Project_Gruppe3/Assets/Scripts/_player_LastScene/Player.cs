using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//DO WHATEVER IS NEEDED HERE FOR THE PLAYER TO JUMP ON PLATFORMS OR WHATEVER

	PlayerHealthDisplay healthDisplay;
	PlayerHealth playerHealth;
	
	// Use this for initialization
	void Start () {
		playerHealth = PlayerHealth.Instance;

		this.gameObject.AddComponent<PlayerHealthDisplay>();
		healthDisplay = this.GetComponent<PlayerHealthDisplay>();

		//****** TODO ******//
		// MovePlayer - jump at least
		// Shoot at cat

	}
	
	// Update is called once per frame
	void Update () {
		healthDisplay.HelmetsTextController ();	

		if (PlayerHealth.CurrentHealth < 5) {
			Debug.Log ("Player is Dead");
			Destroy (this.gameObject);
		}
	}

	// player was hit
	void OnTriggerEnter(Collider obj) {
		if (PlayerHealth.CurrentHealth > 0) {
			healthDisplay.UpdateSliderController (obj, this);
		}
	}
}
