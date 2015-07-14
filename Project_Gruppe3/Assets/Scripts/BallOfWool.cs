using UnityEngine;
using System.Collections;

public class BallOfWool : MonoBehaviour {

	#region Variables (private)

	private AudioSource audio;
	public AudioClip bams;
	private Rigidbody rigid;
	#endregion


	#region Methods

	void Start(){


		rigid = GetComponent<Rigidbody> ();
		//audio = GetComponent<AudioSource>();
	}
	#endregion


	#region Variables (private)

	
	void OnTriggerEnter(Collider coll) {

		// Enemy hits Player --> Player gettin hurt
		if (coll.tag == "pug"){
			//audio.clip = bams;

			//audio.Play();

			Debug.Log("-1 life");
			//isHurt = true;
			
			//pugLife.DecreaseLife();
			GameObject.FindGameObjectWithTag("fer").GetComponent<PugLife>().DecreaseLife();
			//audio=GameObject.FindGameObjectWithTag("fer").GetComponent<AudioSource>();


			Destroy (this.gameObject);
		}
	}

	#endregion
}
