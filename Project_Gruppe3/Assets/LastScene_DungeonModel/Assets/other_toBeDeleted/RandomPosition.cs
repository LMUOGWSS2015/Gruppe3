using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	//bool Alive = true;

	void Start() {
		itembounce();
	}
	
	public void Update () {
		
	}
	
	public void itembounce () {		
		var Geschwindigkeit = 10f;
		var Richtung = new Vector3 (0f, 1f, 0f);
		this.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;

	}
}