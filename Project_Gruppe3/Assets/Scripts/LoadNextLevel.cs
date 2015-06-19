using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		
		// Enemy hits Player --> Player gettin hurt
		if (col.gameObject.name == "Player") {
			Debug.Log("NextLevel_Collision");
			Destroy(gameObject);

			Application.LoadLevel("Menu");
		
		}
	}
}
