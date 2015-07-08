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

	// Use this for initialization
	void Start () 
	{
		//destroy object after x seconds
		Destroy(this.gameObject, destroySeconds);
	}
}
