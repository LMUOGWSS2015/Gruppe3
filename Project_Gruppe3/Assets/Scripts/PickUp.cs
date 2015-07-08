using UnityEngine;
using System.Collections;

public class PickUP : MonoBehaviour 
{
	public GameObject Player;
	void Start()
	{
		 
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "fer")
		{
			GameObject.FindGameObjectWithTag("score").GetComponent<PugLife>().IncreaseLife();
			Destroy(this.gameObject);
		}
	}
}