using UnityEngine;
using System.Collections;

public class EvilCatHealth : MonoBehaviour {

	int maxHealth;
	int healthDecrease;
	int currentHealth;
	
	// Use this for initialization
	void Start () {
		maxHealth = 100;
		healthDecrease = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int MaxHealth {
		get {
			return maxHealth;
		}
	}
	
	
	public int CurrentHealth {
		get {
			return currentHealth;
		}
	}
	
	public void ModifyHealth() {
		currentHealth -= healthDecrease;
		
		if (currentHealth < 1) {
			//DEAD
			Debug.Log("***** Dead! *****");
		}
	}


}
