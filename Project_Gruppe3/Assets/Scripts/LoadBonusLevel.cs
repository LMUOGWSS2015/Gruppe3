using UnityEngine;
using System.Collections;

public class LoadBonusLevel : MonoBehaviour {

	private GameObject player;
	public Vector3 pugPosition;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("pug");
	}


	void Update(){

		pugPosition = player.transform.position;
		HoldInformations.SetPugCurrentPos (pugPosition);
	}
	
	void OnCollisionEnter (Collision col){
		
		// Enemy hits Player --> Player gettin hurt
		if (col.gameObject.tag == "pug") {
			//Debug.Log("NextLevel_Collision");



			Debug.Log(pugPosition);
			HoldInformations.SetPugCurrentPos(pugPosition);

			Debug.Log("Life in level 1 " + HoldInformations.GetLife());

			Application.LoadLevel("BonusLevelNew");
			
		}
	}
}
