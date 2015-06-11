using UnityEngine;
using System.Collections;

public class Helmet : MonoBehaviour 
{
	public GameObject Player;

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "pug")
		{

				GameObject.FindGameObjectWithTag("pug").GetComponent<Score>().helmets++;
				Destroy(this.gameObject);
			}
		}
	}
