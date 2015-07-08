using UnityEngine;
using System.Collections;

public class EnemiesSpawnManager : MonoBehaviour {

	#region Variables (public)

	public GameObject newEnemy;
	//public GameObject player;

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

			



		// Create enemy for each point an enemy
		//foreach (GameObject enemyPoint in enemyPoints) {
		//	float distance = Vector3.Distance (enemyPoint.transform.position, player.transform.position);
			//Debug.Log (distance);

		//	if ((distance <10f)&&(distance>9)){
				//enemyPoint.SetActive(false);
		//		CreateEnemy ();
				//Destroy(enemyPoint);


				//Disablin the spawning point ('Destroy' didnt work)
				//enemyPoint.transform.position = new Vector3 (enemyPoint.transform.position.x,
				  //                                          enemyPoint.transform.position.y - 100f,
				    //                                         enemyPoint.transform.position.z);
			//}




		//}
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
		//anim.Play("CatSkating");
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




