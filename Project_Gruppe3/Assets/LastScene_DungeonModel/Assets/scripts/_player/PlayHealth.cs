using UnityEngine;
using System.Collections;

public class PlayHealth : MonoBehaviour {

	int maxHealth;
	int currentHealth;
	int healthDecrease = 10;
	bool isDead;

	
	// Use this for initialization
	void Start () {
		SetMaxHealth (100);
		SetCurrentHealth (100);
		isDead = false;
	}

	// +++++++++++++++ PUBLIC METHODS +++++++++++++++ 
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
	
	public void UpdateCurrentHealthWhenHit() {
		currentHealth -= healthDecrease;
		
		if (currentHealth < 0) {
			isDead = true;
			
			// code for what comes after death
		}
	}
	
	public bool IsDead {
		get {
			return isDead;
		}
	}

	// +++++++++++++++ PRIVATE METHODS +++++++++++++++
	// which will be primarily used inside this class
	void SetMaxHealth(int maxHealthAmount) {
		maxHealth += maxHealthAmount;
	}


	void SetCurrentHealth(int currentHealthAmount) {
		currentHealth += currentHealthAmount;

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}
