using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	#region Variables (public)

	public static bool isHurt = false;
	public Health health;

	#endregion


	#region Unity event functions

	void Update(){
		//if()
	}

	#endregion


	#region Methods

	void OnCollisionEnter (Collision col)
	{
		// Enemy hits Player --> Player gettin hurt
		if (col.gameObject.name == "Player") 
		{
			Debug.Log("-1 life");
			isHurt = true;

//			Health.lifes--;
//			Debug.Log(Health.lifes);
			health.ModifyHealth(-1);
		}
	}

	#endregion
}
