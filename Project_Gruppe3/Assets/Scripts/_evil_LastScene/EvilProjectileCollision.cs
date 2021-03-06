﻿using UnityEngine;
using System.Collections;

public class EvilProjectileCollision : MonoBehaviour {

	void OnTriggerEnter(Collider obj) {
		if (obj.gameObject.tag == "Player") {
			// destroy the hairball
			Destroy(this.gameObject);
		}
	}

	void OnBecameInvisible() {
		// destroy the hairball
		Destroy(this.gameObject);
	}
}
