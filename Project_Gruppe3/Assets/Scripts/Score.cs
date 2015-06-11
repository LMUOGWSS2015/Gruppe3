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
	private Text uIHelmetScore;
	private Text uITotalScore;

	void Awake()
	{
//		playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
//		energy = GameObject.FindGameObjectsWithTag("Energy");
//		totalEnergy = energy.Length;
//		neededEnergy = Mathf.RoundToInt (totalEnergy * difficultyPercentage);

		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		uIHelmetScore = GameObject.Find ("helmetScore").GetComponent<Text> ();
		uITotalScore=GameObject.Find ("collectedBones").GetComponent<Text> ();
	}
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		uITotalScore.text ="Score: " + score.ToString ();
		uIHelmetScore.text ="Helmets: " + helmets.ToString ();

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
