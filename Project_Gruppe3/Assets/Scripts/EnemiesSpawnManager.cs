using UnityEngine;
using System.Collections;

public class EnemiesSpawnManager : MonoBehaviour {

	#region Variables (public)

	public GameObject newEnemy;
	public GameObject player;

	#endregion


	#region Variables (private)

	private GameObject[] enemyPoints;

	#endregion
	

	#region Unity event functions

	void Update(){
		// Get all Spawning Points
		if(enemyPoints == null)
			enemyPoints = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");

		// Create enemy for each point an enemy
		foreach (GameObject enemyPoint in enemyPoints) {
			float distance = Vector3.Distance (enemyPoint.transform.position, player.transform.position);
			//Debug.Log (distance);

			if (distance < 10f){
			
				CreateEnemy ();

				// Disablin the spawning point ('Destroy' didnt work)
				enemyPoint.transform.position = new Vector3 (enemyPoint.transform.position.x,
				                                             enemyPoint.transform.position.y - 100f,
				                                             enemyPoint.transform.position.z);
			} 
		}
	}

	#endregion


	#region Methods

	void CreateEnemy(){

		// Creatin enemy infront of the player's view
		Instantiate(newEnemy, 
		            player.transform.position + player.transform.forward * 40f,
		            new Quaternion( 0.0f, player.transform.rotation.y, 0.0f, player.transform.rotation.w));
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




