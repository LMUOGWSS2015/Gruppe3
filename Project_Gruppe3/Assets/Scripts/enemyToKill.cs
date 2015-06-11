using UnityEngine;
using System.Collections;

public class enemyToKill : MonoBehaviour
{
	public GameObject dogsBone;
//	public int numberOfObjects;
	public int numbOfObj;
	public float radius = 1f;
	//public RaycastHit hit;
	Vector3 startPosition;

	void OnTriggerEnter(Collider coll)
	{
		// if Enemy collides with the Bullet (waterDrop), destroy it itself
		if (coll.gameObject.tag == "waterDrop")
		{
			// run destruction function
			Destroy(this.gameObject);
			spawnDogBones();
			GameObject.FindGameObjectWithTag("pug").GetComponent<Score>().score+=100;

		}
		else{
			//do nothing
		}
	}

	void OnCollisionEnter(Collision coll){
		ContactPoint contact = coll.contacts[0];
		startPosition = contact.point;
		Debug.Log (startPosition.ToString () +coll.gameObject.ToString());
	}


	void spawnDogBones(){

		//Vector3 startPosition = new Vector3 (transform.position.x + 0.01F,
	    //                               transform.position.y + 5.2F,
	    //                                 transform.position.z);
		//add velocity
		// Vector3 velocityChangeForShot = 1.02f * (startPosition);
		
	
		// spawn 1 kugel
	    //	Instantiate (bulletSphere, velocityChangeForShot, transform.rotation);


		//Vector3 position = transform.position;
		// Clone the objects that are "in" the box.
//		Vector3 offset = new Vector3 (1.1, 1, 1.5);
//
//		Vector3 position = new Vector3 (transform.position.x, transform.position.y + 6.0F, transform.position.z);
//
//		foreach (GameObject DogsBone in DogsBones)
//		{
//			if (DogsBone != null)
//			{
//				position=position*offset;
//				Instantiate(DogsBone, position, Quaternion.identity);
//			}
//
//		}
      //Vector3 position = new Vector3 (transform.position.x, transform.position.y + 6.0F, transform.position.z);

		//for (int i = 0; i < numbOfObj; i++) {
		//	float angle = i * Mathf.PI * 2.0F / numbOfObj;
		//	Vector3 position =new Vector3(Mathf.Cos (angle), 1.0F, Mathf.Sin (angle))*4.0F;

		//	Vector3 position = new Vector3((Mathf.Cos (angle)+startPosition.x)/4, 4.0F, ((Mathf.Sin(angle)+startPosition.z)/4)+1.0F);
		   //Vector3 position = new Vector3(startPosition.x+i+2, 6+i, startPosition.z+);
			//(startPosition.x+i+2, 6+i, startPosition.z+i+2);
		//	Vector3 trajectory = UnityEngine.Random.insideUnitCircle*3F;
		//	Vector3 position = new Vector3(startPosition.x*i,startPosition.y+(i*2), startPosition.z);
		//	position+=trajectory;
			Instantiate( dogsBone, startPosition + ( transform.right * (-3) )+(transform.up*3), transform.rotation );
			Instantiate( dogsBone, startPosition + ( transform.right * 3 )+(transform.up*3), transform.rotation );


			//Instantiate(dogsBone, position, transform.rotation);
			//Debug.Log (position.ToString());




	}

}
