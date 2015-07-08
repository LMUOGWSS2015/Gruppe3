using UnityEngine;
using System.Collections;

public class minusHelmet : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "fer")
		{
			GameObject.FindGameObjectWithTag("fer").GetComponent<PugLife>().DecreaseLife();
			Destroy(this.gameObject);
		}
	}
}
