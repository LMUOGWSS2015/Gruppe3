using UnityEngine;
using System.Collections;

public class BallOfWool : MonoBehaviour {
	
	#region Variables (public)
	
	//public static bool isHurt = false;
	//public PugLife pugLife;
	public GameObject dogsBone;
	//	public int numberOfObjects;
	public int numbOfObj;
	public float radius = 1f;
	//public RaycastHit hit;
	Vector3 startPosition;
	
	#endregion
	
	
	#region Methods
	
	void OnCollisionEnter (Collision col){
		
		// Enemy hits Player --> Player gettin hurt
		if (col.gameObject.name == "Player"){
			Debug.Log("-1 life");
			//isHurt = true;
			
			//pugLife.DecreaseLife();
			GameObject.FindGameObjectWithTag("pug").GetComponent<PugLife>().DecreaseLife();
		}
	}
	
	void OnTriggerEnter (Collider coll){
		
		// if Enemy collides with the Bullet (waterDrop), destroy it itself
		if (coll.gameObject.tag == "waterDrop") {
			
			startPosition = coll.transform.position;
			// run destruction function
			Destroy (this.gameObject);
			
			// Adding score points for killing an enemies
			GameObject.FindGameObjectWithTag ("pug").GetComponent<Score> ().score += 100;
			HoldInformations.SetScore(GameObject.FindGameObjectWithTag ("pug").GetComponent<Score> ().score);
			
		} 
	}

	#endregion
}
