﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	PlayerHealthDisplay healthDisplay;
	PlayerHealth playerHealth;

	public AudioClip steam;
	private AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		playerHealth = PlayerHealth.Instance;

		this.gameObject.AddComponent<PlayerHealthDisplay>();
		healthDisplay = this.GetComponent<PlayerHealthDisplay>();

		audioSrc = GetComponent<AudioSource> ();
		audioSrc.clip = steam;
		audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		healthDisplay.HelmetsTextController ();	
	}

	// player was hit
	void OnTriggerEnter(Collider obj) {
		if (PlayerHealth.CurrentHealth > 0) {
			healthDisplay.UpdateSliderController (obj, this);
		} else if (PlayerHealth.CurrentHealth < 5) {
			Debug.Log ("Player is Dead");
			audioSrc.Stop ();
			
			Destroy (this.gameObject);
			
			if (PlayerHealth.Helmets >= 1) {
				PlayerHealth.Helmets -= 1;
				Application.LoadLevel (Application.loadedLevel);
			} else {
				Application.LoadLevel ("NovaMenu");
			}
		}
	}
}
