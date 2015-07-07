using UnityEngine;
using System.Collections;

public class EvilHealth : MonoBehaviour{
	
	private static EvilHealth _instance;
	
	static int maxHealth;
	static int currentHealth;
	static int healthDecrease = 10;

	public static EvilHealth Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<EvilHealth>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);

				//let EvilCat live a little longer than the pug
				SetMaxHealth (145);
				SetCurrentHealth (145);
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
