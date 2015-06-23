using UnityEngine;
using System.Collections;

public class CatGeneration : MonoBehaviour {

	public GameObject[] flyingCats;
	private Vector3 startPoint;
	private int counter;

	private Vector3 movementV = Vector3.left * 0.1f;
	//private Vector3 movementH = Vector3.up * 0.1f;
	private float speed = 0.1f;


	// Use this for initialization
	void Start () {
		counter = 0;
		flyingCats = new GameObject[10];
		startPoint =new Vector3(15.0f,2.5f,0);
		GameObject cat = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cat.name = "Cats";
		cat.transform.position = startPoint;
		for (int i =0; i<10; i++) {
			//Adding objects to array
			flyingCats [i] = cat;

		}
	}




	// Update is called once per frame
	void Update () {
		/*	if(flyingCats[0].transform.position.x > 15)) {
				flyingCats[0].transform.position = startPoint;
				movementV = Vector3.left * speed;
				
				if(speed < 0.5f){
					speed = speed + 0.08f;
				}

			}
		flyingCats[0].transform.Translate(movementV);

		}
			
		if(flyingCats[1].transform.position.x > 5) {
				flyingCats[1].transform.position = startPoint;
				movementV = Vector3.left * speed;
				
				if(speed < 0.5f){
					speed = speed + 0.08f;
				}
				
			}
			flyingCats[1].transform.Translate(movementV);
			
		}*/

	}

}
