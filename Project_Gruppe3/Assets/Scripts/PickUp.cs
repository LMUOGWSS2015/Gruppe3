﻿using UnityEngine;
using System.Collections;

public class PickUP : MonoBehaviour 
{
	public GameObject Player;
	void Start()
	{
		 
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "pug")
		{
			GameObject.FindGameObjectWithTag("score").GetComponent<PugLife>().increaseLife();
			Destroy(this.gameObject);
		}
	}
}