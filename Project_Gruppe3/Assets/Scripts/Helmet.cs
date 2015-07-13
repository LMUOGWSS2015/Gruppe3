using UnityEngine;
using System.Collections;

public class Helmet : MonoBehaviour 
{
	//public GameObject Player;
	public float destroySeconds;

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "fer")
		{
			GameObject.FindGameObjectWithTag("fer").GetComponent<PugLife>().IncreaseLife();
				Destroy(this.gameObject);
		}
	}

}
