using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TestEvilCat : MonoBehaviour
{
	
	Vector3 startPos;
	Vector3 endPos;
	
	protected void Start() {
		startPos = transform.position;
		endPos = transform.position;
	}
	
	protected void Update() {

		
	}
	
	public GameObject healthBarSlider;  //reference for slider
	private bool isGameOver = false; //flag to see if game is over
	
	// cat was hit
	void OnTriggerEnter(Collider obj) {
		
		//Text text = helmetsCountDisplay.GetComponent<Text>(); //get the text component in the gameobject you assigned
		//text.text = "insert some text here"; 
		
		Slider slider = healthBarSlider.GetComponent<Slider> ();
		Debug.Log("Where's the Slider?");
		if(obj.gameObject.tag=="Projectile" && slider.value>0){
			Debug.Log("Slider detected");
			slider.value -=10f;  //reduce health
		}
		else{
			EvilHealth evilHealth = new EvilHealth();
			evilHealth.setIsDead(true);
		}
		
		// dying code here
		//if (obj.gameObject.tag == "Evil") {
		//	
		//	obj.gameObject.transform.rotation = Quaternion.identity;
		//	obj.gameObject.transform.position = new Vector3(20f, -3f, 8f);
		//	Destroy(this.gameObject);
		//}
	}
}