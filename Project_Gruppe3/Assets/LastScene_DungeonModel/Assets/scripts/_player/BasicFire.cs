using UnityEngine;
using System.Collections;

public class BasicFire : MonoBehaviour {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			GameObject projectileInstance;
			projectileInstance = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
			projectileInstance.name = "Projectile";

			Rigidbody projectileRbInstance;
			projectileRbInstance = projectileInstance.GetComponent<Rigidbody>();
			projectileRbInstance.velocity = transform.TransformDirection(20, 0, 0);
		}
	
	}
}
