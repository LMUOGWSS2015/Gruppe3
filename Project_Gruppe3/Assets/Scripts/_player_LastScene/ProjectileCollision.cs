using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	void OnTriggerEnter(Collider obj) {
		if (obj.gameObject.tag == "Evil" || obj.gameObject.tag == "HairBall") {
			// destroy the projectile
			Destroy(this.gameObject);
		}
	}
	
	void OnBecameInvisible() {
		// destroy the projectile
		Destroy(this.gameObject);
	}
}	
