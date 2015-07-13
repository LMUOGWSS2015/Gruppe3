using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EvilCat : MonoBehaviour
{
	EvilHealthDisplay healthDisplay;
	EvilHealth evilHealth;
	EvilBasicFire fire;
	MoveCat move;
	
	protected void Start() {
		// this is just used to instantiate the health of the evil cat (class with static methods) as soon as the evil cat itself is instatiated
		evilHealth = EvilHealth.Instance;

		this.gameObject.AddComponent<EvilHealthDisplay>();
		healthDisplay = this.GetComponent<EvilHealthDisplay>();

		this.gameObject.AddComponent<MoveCat>();
		move = this.GetComponent<MoveCat>();
		move.AddVectorsToList ();

		this.gameObject.AddComponent<EvilBasicFire>();
		fire = this.GetComponent<EvilBasicFire>();
 		fire.ShootAtPlayer ();
	}
	
	protected void Update() {
		if (EvilHealth.CurrentHealth <= 5) {
			Debug.Log ("Evil Cat is Dead");
			Destroy (this.gameObject);
		} else if (!move.HasMoved) {
			move.CalculateNewPosition ();
		} 
		move.MoveCatToNewPosition (fire);
	}
	
	// cat was hit
	void OnTriggerEnter(Collider obj) {
		if (EvilHealth.CurrentHealth > 0) {
			healthDisplay.UpdateSliderController (obj, this);
		}
	}
}