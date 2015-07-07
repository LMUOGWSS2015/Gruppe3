using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	private static PlayerHealth _instance;
	
	static int maxHealth;
	static int currentHealth;
	static int healthDecrease = 10;
	static int helmets;
	
	public static PlayerHealth Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<PlayerHealth>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
				
				SetMaxHealth (100);
				SetCurrentHealth (100);

				int life = HoldInformations.GetLife ();
				helmets = life;
			}
			
			return _instance;
		}
	}
	
	// +++++++++++++++ PUBLIC METHODS +++++++++++++++ 

	public static int CurrentHealth {
		get {
			return currentHealth;
		}
		set {
			currentHealth -= value; //reduce currentHealth by value!
		}
	}

	public static int Helmets {
		get {
			return helmets;
		}
		set {
			helmets = value;
		}
	}

	// +++++++++++++++ PRIVATE METHODS +++++++++++++++
	// which will be primarily used inside this class
	static void SetMaxHealth(int maxHealthAmount) {
		maxHealth += maxHealthAmount;
	}

	static void SetCurrentHealth(int currentHealthAmount) {
		currentHealth += currentHealthAmount;
		
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}
