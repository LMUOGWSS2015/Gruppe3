using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITexter : MonoBehaviour {

	public int helmets;
	public int score;

	private Text uIHelmetScore;
	private Text uITotalScore;
	private Score scoreState;

	// Use this for initialization
	void Awake () {
		scoreState = GameObject.FindGameObjectWithTag("pug").GetComponent<Score> ();
		uIHelmetScore = GameObject.Find ("helmetScore").GetComponent<Text> ();
		uITotalScore=GameObject.Find ("collectedBones").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		uITotalScore.text ="Score: " + scoreState.score.ToString ();
		uIHelmetScore.text ="Helmets: " + scoreState.helmets.ToString ();

	
	}
}
