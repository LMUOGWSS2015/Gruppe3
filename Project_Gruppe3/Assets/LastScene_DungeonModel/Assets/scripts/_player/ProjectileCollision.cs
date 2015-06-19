using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	/*
	void OnCollisionEnter (Collision collision) {

		Debug.Log ("Detected collision with: " + collision.gameObject.name);
		if (collision.gameObject.tag == "Evil") {
			Debug.Log ("Detected collision the EvilCat!");
		}
		Destroy (this.gameObject);
	}

	*/
	void OnTriggerEnter(Collider obj) {
		if (obj.gameObject.tag == "Evil") {

			obj.gameObject.transform.rotation = Quaternion.identity;
			obj.gameObject.transform.position = new Vector3(20f, -3f, 8f);
			Destroy(this.gameObject);
		}
	}
}	
