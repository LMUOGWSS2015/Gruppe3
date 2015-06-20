using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UITexter : MonoBehaviour {

	#region Variables (private)

	private Text uIHelmetScore;
	private Text uITotalScore;
	private Score scoreState;
	private PugLife lifeState;

	#endregion


	#region Unity event functions
	
	// Use this for initialization
	void Awake () {
		scoreState = GameObject.FindGameObjectWithTag("pug").GetComponent<Score> ();
		lifeState = GameObject.FindGameObjectWithTag("pug").GetComponent<PugLife> ();
		
		uIHelmetScore = GameObject.Find ("helmetScore").GetComponent<Text> ();
		uITotalScore=GameObject.Find ("collectedBones").GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		uITotalScore.text = "Score: " + HoldInformations.GetScore ().ToString ();
		uIHelmetScore.text = "Helmets: " + HoldInformations.GetLife ().ToString ();		
		Debug.Log(HoldInformations.GetLife ().ToString ());
		
		
	}

	#endregion
}
