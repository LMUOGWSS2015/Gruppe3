using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
	public float timeLimit = 10.0f;
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

		timeLimit -= Time.deltaTime;
	
		this.timelimitLevel -= Time.deltaTime;
	}

	void OnCollisionEnter(Collision col){
	
		//detect "collision" with target
		if (col.gameObject.name == "Target" && (timeLimit > 0)) {
			//detect collision with target
			if (col.gameObject.name == "Target" && (timelimitLevel > 0)) {
				//destroy target-wall
				Destroy (col.gameObject); 

				//back to main game
				Application.LoadLevel ("LastScene");

			}
		//TODO
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
	}

	//Zeitdisplay in der GUI :) 
	void OnGUI(){
		if (timelimitLevel  > 0) {
			GUI.Label (new Rect (125, 25, 200, 100), "Time Remaining: " + (int)timelimitLevel );
		} else {
			GUI.Label(new Rect(125, 25, 100, 100), "Time is up!");
			decreaseLive();
		//	ResetScene(); 
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
			Application.LoadLevel("Menu");
			
			HoldInformations.SetLife (1);
			/*
  				restartTimer+= Time.deltaTime;
				if(restartTimer >= restartDelay){
					Application.LoadLevel("Menu");
				}
*/
		} else {
			//reset scene
			ResetScene (); 
		}
	}


}
