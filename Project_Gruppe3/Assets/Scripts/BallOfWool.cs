using UnityEngine;
using System.Collections;

public class BallOfWool : MonoBehaviour {
	
	#region Variables (public)

	public GameObject dogsBone;
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

	#endregion
}
