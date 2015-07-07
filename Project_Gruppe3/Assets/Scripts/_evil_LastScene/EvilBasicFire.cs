using UnityEngine;
using System.Collections;

public class EvilBasicFire : MonoBehaviour {

	GameObject player;
	bool hasShot;

	public GameObject hairballPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool HasShot {
		get {
			return hasShot;
		}
		set {
			hasShot = value;
		}
	}

	public void ShootAtPlayer() {
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot ()
	{
		hasShot = true;

		player = GameObject.FindGameObjectWithTag ("Player");
		transform.LookAt(player.transform);
		
		GameObject hairballInstance;
		hairballInstance = (GameObject)Instantiate(hairballPrefab, transform.position, transform.rotation);
		hairballInstance.name = "HairBall";
		
		Rigidbody hairballRbInstance;
		hairballRbInstance = hairballInstance.GetComponent<Rigidbody>();
		const int SHOOTING_FORCE = 1800;
		hairballRbInstance.AddForce(transform.forward * SHOOTING_FORCE);

		yield return new WaitForSeconds(2.3f);

		hasShot = false;
	}
}
