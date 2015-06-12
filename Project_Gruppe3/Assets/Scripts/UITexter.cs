using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITexter : MonoBehaviour {

	private Text uIHelmetScore;
	private Text uITotalScore;
	private Score scoreState;
	private PugLife lifeState;


	// Use this for initialization
	void Awake () {
		scoreState = GameObject.FindGameObjectWithTag("pug").GetComponent<Score> ();
		lifeState = GameObject.FindGameObjectWithTag("pug").GetComponent<PugLife> ();

		uIHelmetScore = GameObject.Find ("helmetScore").GetComponent<Text> ();
		uITotalScore=GameObject.Find ("collectedBones").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		uITotalScore.text ="Score: " + scoreState.score.ToString ();
		uIHelmetScore.text ="Helmets: " + lifeState.helmets.ToString ();

	
	}
}
