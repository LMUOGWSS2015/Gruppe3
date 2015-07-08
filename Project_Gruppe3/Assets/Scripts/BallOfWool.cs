using UnityEngine;
using System.Collections;

public class BallOfWool : MonoBehaviour {

	#region Variables (private)

	private AudioSource audio;

	#endregion


	#region Methods

	void Start(){

		audio = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter (Collision col){
		
		// Enemy hits Player --> Player gettin hurt
		if (GameObject.FindGameObjectWithTag("pug")){
			Debug.Log("-1 life");
			//isHurt = true;
			
			//pugLife.DecreaseLife();
			GameObject.FindGameObjectWithTag("fer").GetComponent<PugLife>().DecreaseLife();

			audio.Play();
		}
	}

	#endregion
}
