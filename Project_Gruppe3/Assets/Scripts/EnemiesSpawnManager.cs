using UnityEngine;
using System.Collections;

public class EnemiesSpawnManager : MonoBehaviour {

	#region Variables (public)

	public GameObject newEnemy;

	#endregion


	#region Variables (private)

	private GameObject[] enemyPoints;
	private GameObject pug;
	private Animation anim;
	
	#endregion
	

	#region Unity event functions

	void Update(){
		// Get all Spawning Points
		pug=GameObject.FindGameObjectWithTag("fer");

		if(enemyPoints == null)
			enemyPoints = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");

		//Destroy is now Working 
		float distance = Vector3.Distance (this.gameObject.transform.position, pug.transform.position);
		if (distance < 10f) {
			CreateEnemy();
			Destroy(this.gameObject);
		}
	}

	#endregion


	#region Methods

	void CreateEnemy(){

		// Creatin enemy infront of the player's view
		Instantiate(newEnemy, 
		            pug.transform.position + pug.transform.forward * 30f,
		            new Quaternion( 0.0f, pug.transform.rotation.y, 0.0f, pug.transform.rotation.w));
		Debug.Log (pug.transform.position + "," + pug.transform.forward);
	}

	/**
	 * OLD METHOD FOR CREATIN ENEMIES
	 * */
		/*void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Player") 
		{
			Debug.Log("Spawn point triggered");
			Destroy(gameObject);

			CreateEnemy();
		}
	}*/

	#endregion
}




