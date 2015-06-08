using UnityEngine;
using System.Collections;

public class CatGeneration : MonoBehaviour {

	public GameObject[] flyingCats;
	private Vector3 movement = Vector3.left * 0.1f;

	// Use this for initialization
	void Start () {

		flyingCats = new GameObject[10];

		GameObject cat = GameObject.CreatePrimitive(PrimitiveType.Cube);

		for (int i =0; i<10; i++) {
			//Adding objects to array
			flyingCats [i] = cat;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 1)
			movement = Vector3.left * 0.1f;

		else if (transform.position.x < -1)
			movement = Vector3.right * 0.1f;
		
		transform.Translate(movement);

	}
}
