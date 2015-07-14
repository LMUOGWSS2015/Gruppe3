using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
	public int lives;
	public float timeLimit;
	public Font MyFont;
	public float restartDelay = 3f;
	public float restartTimer;
	public bool timeupbool;

	
	private Animator anim;
	void Start(){
		timeLimit = 20.0f;
		timeupbool = false;
		lives = HoldInformations.GetLife ();
	}
	void Awake()
	{
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		
	}

	// Update is called once per frame
	void Update () {
			
			timeLimit -= Time.deltaTime;
		if (timeLimit <= 0) {
			decreaseLive ();
		}
	
	}
	
	void OnTriggerEnter(Collider col){
		//detect collision with target
		Debug.Log("ColEnter: " + col.gameObject.tag);

		if ((col.gameObject.tag == "Player") && HoldInformations.GetJump()== true) {
			Debug.Log("Test1");
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
		Debug.Log (HoldInformations.GetLife());
		lives = HoldInformations.GetLife()- 1; 

		if(lives> 0) {
			HoldInformations.SetLife (lives);
			//reset scene
			Application.LoadLevel(Application.loadedLevel);
		} 
		if(lives<=0 ){
			HoldInformations.SetLife (lives);
			Debug.Log ("Game Over!");
			anim.SetTrigger ("IsGameOver");
			Application.LoadLevel("NovaMenu");
			
			HoldInformations.SetLife (1);
		}  
	}

	void OnGUI(){
		GUI.skin.font = MyFont;
		
		if (timeLimit > 0) {
			GUI.Label (new Rect (125, 100, 200, 100), "Time Remaining: " + (int)timeLimit);
			
		}else {
			GUI.Label(new Rect(125, 100, 100, 100), "Time is up!");

		}
	}

	
}
