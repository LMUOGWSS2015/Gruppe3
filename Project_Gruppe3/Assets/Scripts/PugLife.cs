using UnityEngine;
using System.Collections;

public class PugLife : MonoBehaviour {

	#region Variables (public)
	
	public float restartDelay = 3f;

	#endregion


	#region Variables (private)
	
	private Animator anim;
	private float restartTimer;
	private int helmets;

	#endregion


	#region Methods
	
	// Use this for initialization
	void Start () {
		helmets = HoldInformations.GetLife ();
	}
	
	public void IncreaseLife(){
		helmets += 1;
		HoldInformations.SetLife (helmets);
		//Debug.Log("Puglife setlife" + helmets);
	}
	
	public void DecreaseLife(){
		helmets -= 1;
		HoldInformations.SetLife (helmets);
	}

	#endregion


	#region Unity event functions

	void Awake()
	{
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(helmets == 0)
		{
			Destroy(GetComponent<Animator>());
			Debug.Log ("Game Over!");
			anim.SetTrigger("IsGameOver");
			
			restartTimer+= Time.deltaTime;
			
			if(restartTimer >= restartDelay){
				Application.LoadLevel("NovaMenu");
			}
		}
	}

	#endregion

}

