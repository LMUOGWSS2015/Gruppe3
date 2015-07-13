using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
	public int lives;
	public float restartDelay = 3f;
	public float restartTimer;


	private Animator anim;

	void Awake()
	{
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		
	}
	public float timelimitLevel = 20.0f;

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
			//detect collision with target
			if (col.gameObject.name == "HUDCanvas/Target") {
				//destroy target-wall
				Destroy (col.gameObject); 

				//back to main game
				Application.LoadLevel ("LastScene");

			}
			//detect collision with cats
			else if (col.gameObject.name == "Cats") {
					Debug.Log ("-1 Live");
					decreaseLive ();
					//reset scene#
					ResetScene (); 
					//TODO
					//life -1
				}

	}

	//reset scene
	void ResetScene(){
		Application.LoadLevel(Application.loadedLevel);
	}

	// one live less
	public void decreaseLive (){
		lives = HoldInformations.GetLife()- 1; 
		HoldInformations.SetLife (lives);
		
		if (lives <= 0) {
			Debug.Log ("Game Over!");
			anim.SetTrigger ("IsGameOver");
			Application.LoadLevel("NovaMenu");
			
			HoldInformations.SetLife (1);

		} else {
			//reset scene
			ResetScene (); 
		}
	}


}
