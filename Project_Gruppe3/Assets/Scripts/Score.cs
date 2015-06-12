using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]


public class Score : MonoBehaviour {


	public int helmets=3;
	public int score;

	private Animator anim;
	public float restartDelay = 3f;
	private float restartTimer;



	void Awake()
	{


		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();

	}
	 

	
	// Update is called once per frame
	void Update () {

	//	uITotalScore.text ="Score: " + score.ToString ();
	//	uIHelmetScore.text ="Helmets: " + helmets.ToString ();

		if(helmets==0)
		{
			//print ("Game Over!");
			anim.SetTrigger("isGameOver");
			
			restartTimer+= Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			
		}
	}
	
	}
