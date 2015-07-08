using UnityEngine;
using System.Collections;

public class BallOfWoolSpawnManager : MonoBehaviour {
	
	#region Variables (public)
	
	public GameObject newBallOfWool;

	#endregion
	
	
	#region Variables (private)
	
	private GameObject[] ballOfWoolPoints;
	private GameObject pug;
	
	#endregion
	
	
	#region Unity event functions
	
	void Update(){
		// Get all Spawning Points
		pug=GameObject.FindGameObjectWithTag("fer");
		
		if(ballOfWoolPoints == null)
			ballOfWoolPoints = GameObject.FindGameObjectsWithTag ("BallOfWoolSpawnPoint");

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
		Instantiate(newBallOfWool, 
		            pug.transform.position + pug.transform.forward * 30f,
		            new Quaternion( 0.0f, pug.transform.rotation.y, 0.0f, pug.transform.rotation.w));
	}
	
	#endregion
}




