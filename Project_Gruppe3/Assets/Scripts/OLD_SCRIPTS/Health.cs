/*using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public static int lifes;
	private static bool playerDead;
	private RigPlayerMovement playerMovement; 


	// Use this for initialization
	void Start () {
		playerMovement = GetComponent<RigPlayerMovement> ();
		lifes = 3;
		playerDead = false;
		//OnGUI ();
	}

	void Update(){

		if (lifes < 0) {
			playerDead = true;
			Debug.Log ("GAMEOVER! -.-");
			//After death no player's movement possible
			playerMovement.enabled = false;
		} 
	}

}*/

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	#region Variables (public)

	public int startingHealth;
	public GUITexture heartGUI;
	public int maxHeartsPerRow;

	#endregion


	#region Variables (private)

	private ArrayList hearts  = new ArrayList ();
	private float spacingX;
	private float spacingY;
	private static int currentHealth;
	private int maxHealth;
	private RigPlayerMovement playerMovement; 

	#endregion


	#region Unity event functions

	void Start (){

		currentHealth = startingHealth;
		Debug.Log ("Start_currentHealth: " + currentHealth);

		spacingX = heartGUI.pixelInset.width;
		spacingY = heartGUI.pixelInset.height; 
		AddHearts (startingHealth);

	}

	#endregion


	#region Methods

	public void AddHearts(int n){
		for (int i = 0; i < n; i++) {

			// GUI : Display heart
			Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject, transform.position, Quaternion.identity)).transform;
			newHeart.parent = transform;

			int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
			int x = hearts.Count - y * maxHeartsPerRow;

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX, y * spacingY, 58, 58);

			hearts.Add(newHeart);

			//currentHealth++

		}
		maxHealth += n;
		currentHealth = maxHealth;
		Debug.Log(currentHealth);
		UpdateHearts ();
	}

	public void ModifyHealth(int amount){
		Debug.Log ("currentHealth before - : "+ currentHealth);
		currentHealth--;
		//currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
		UpdateHearts ();
		Debug.Log ("currentHealth_mod: " + currentHealth);
	}

	public void UpdateHearts(){

	}
		

	#endregion
}
