﻿using UnityEngine;
using System.Collections;

public class BasicFire : MonoBehaviour {

	//set the prefab of the Projectile here
	public GameObject projectilePrefab;

	public AudioClip pew;
	private AudioSource audioSrc;

	GameObject evilCat;

	// Use this for initialization
	void Start () {
		evilCat = GameObject.FindGameObjectWithTag ("Evil");	
	}
	
	// Update is called once per frame
	void Update () {		
		if (evilCat != null) {
			Vector3 evilCatPostition = new Vector3(evilCat.transform.position.x, 
			                                      transform.position.y,
			                                      evilCat.transform.position.z) ;
			this.transform.LookAt( evilCatPostition ) ;

			if (Input.GetButtonDown ("Fire1")) { //shoot when left mouse button is clicked
				GameObject projectileInstance;
				projectileInstance = (GameObject)Instantiate (projectilePrefab, transform.position, transform.rotation);
				projectileInstance.name = "Projectile";
			
				Rigidbody projectileRbInstance;
				projectileRbInstance = projectileInstance.GetComponent<Rigidbody> ();
				const int SHOOTING_FORCE = 2000;
				projectileRbInstance.AddForce (transform.forward * SHOOTING_FORCE);


				audioSrc = GetComponent<AudioSource> ();
				audioSrc.clip = pew;
				audioSrc.Play ();
			}
		}
	}
}
