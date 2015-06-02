using UnityEngine;
using System.Collections;

public class enemyToKill : MonoBehaviour
{

	void OnTriggerEnter(Collider coll)
	{
		// if Enemy collides with the Bullet (waterDrop), destroy it itself
		if (coll.gameObject.tag == "waterDrop")
		{
			// run destruction function
			Destroy(this.gameObject);
		}
		else{
			//do nothing
		}
	}
}
