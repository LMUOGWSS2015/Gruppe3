using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	PlayerHealthDisplay healthDisplay;
	PlayerHealth playerHealth;
	
	public AudioClip steam;
	AudioSource audioSrc;
	
	Animator anim;
	float restartDelay = 1f;
	float restartTimer;
	
	void Awake() {
		anim = GameObject.Find ("HUDCanvas").GetComponent<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		playerHealth = PlayerHealth.Instance;
		
		this.gameObject.AddComponent<PlayerHealthDisplay>();
		healthDisplay = this.GetComponent<PlayerHealthDisplay>();
		
		audioSrc = GetComponent<AudioSource> ();
		audioSrc.clip = steam;
		audioSrc.Play();
	}
	
	// Update is called once per frame
	void Update () {
		healthDisplay.HelmetsTextController ();	

		if (PlayerHealth.CurrentHealth < 10) {
			Debug.Log ("Player is Dead");
			audioSrc.Stop ();
			PlayerHealth.Helmets -= 1;
			Destroy (this.gameObject);
			
			if (PlayerHealth.Helmets >= 1) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (PlayerHealth.Helmets == 0) {
			Debug.Log ("Game Over!");
			anim.SetTrigger("IsGameOver");
			Destroy(GetComponent<Animator>());

			restartTimer+= Time.deltaTime;
			
			if(restartTimer >= restartDelay){
				Application.LoadLevel("NovaMenu");
			}
		}

	}
	
	// player was hit
	void OnTriggerEnter(Collider obj) {
		if (PlayerHealth.CurrentHealth >= 10) {
			healthDisplay.UpdateSliderController (obj, this);
		}
	}
}
