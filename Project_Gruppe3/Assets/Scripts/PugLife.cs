using UnityEngine;
using System.Collections;

public class PugLife : MonoBehaviour {

	public GameObject Player;
	public int helmets;
	private Animator anim;
	public float restartDelay = 3f;
	private float restartTimer;

	// Use this for initialization
	void Start () {
	
	}

	public void increaseLife(){
		helmets += 1;
	}

	public void decreaseLife(){
		helmets -= 1;
	}

	void Awake()
	{
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		
	}

	
	// Update is called once per frame
	void Update () {

		if(helmets == 0)
		{
			Debug.Log ("Game Over!");
			anim.SetTrigger("IsGameOver");
			
			restartTimer+= Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel("Menu");
			}
		}
	}	
}

