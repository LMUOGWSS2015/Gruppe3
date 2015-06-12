using UnityEngine;
using System.Collections;

public class CatGeneration : MonoBehaviour {

	/*public GameObject[] flyingCats;
	private Vector3 movementV = Vector3.left * 0.1f;
	private Vector3 movementH = Vector3.up * 0.1f;
	private Vector3 startPoint;
	private float speed = 0.1f;*/
	

	// Use this for initialization
	void Start () {

		/*flyingCats = new GameObject[10];
		startPoint =new Vector3(25.0f,0,0);
		GameObject cat = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cat.transform.position = startPoint;
		for (int i =0; i<10; i++) {
			//Adding objects to array
			flyingCats [i] = cat;

		}*/
	}




	// Update is called once per frame
	void Update () {

		/*if (flyingCats[0].transform.position.x > 20) {
			movementV = Vector3.left * speed;
			if(flyingCats[0].transform.position.y < 20){
				movementH = Vector3.up * 0.1f;
			}
			else if(flyingCats[0].transform.position.y > 20){

				movementH = Vector3.down * 0.1f;
			}

		} else if (flyingCats[0].transform.position.x < -30) {
			flyingCats[0].transform.position = startPoint;
			movementV = Vector3.left * speed;

			if(speed < 0.5f){
				speed = speed + 0.08f;
			}
			//movementH = Vector3.down * 0.1f;

		}
		
		flyingCats[0].transform.Translate(movementV);
		flyingCats[0].transform.Translate(movementH);*/

	}
}
