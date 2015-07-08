using UnityEngine;
using System.Collections;

public class DogsBone : MonoBehaviour
{
	#region Variables (public)

	public float speedForTheThrowUp;
	public float destroySeconds;
	public float bounceSpeed;
	public float bounce;
	public bool isJumping=true;
	public int counter;

	#endregion


	#region Variables (private)

	private Rigidbody rigid;

	#endregion


	#region Unity event functions

	// Use this for initialization
	void Start ()
	{

		// cache component
		rigid = GetComponent<Rigidbody> ();
		
		
		//destroy object after x seconds
		Destroy (this.gameObject, destroySeconds);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
		{
			// add forward force to the bullet
		//rigid.velocity = transform.up * speedForTheThrowUp;
		//rigid.rotation = Quaternion.Euler(0.0f, 0.0f, 1F);

		MoveUpAndDown ();
		//Debug.Log (rigid.position.ToString ()+"aus klasse");

		}
		
		void OnTriggerEnter(Collider coll)
		{
		if (coll.tag == "pug") {
			// if bullet collides with anything, destroy it
			Destroy (this.gameObject);
			GameObject.FindGameObjectWithTag("fer").GetComponent<Score>().score+=100;
			HoldInformations.SetScore(GameObject.FindGameObjectWithTag("fer").GetComponent<Score>().score);
		}
	}

	#endregion


	#region Methods

	void MoveUpAndDown(){
		//Debug.Log (rigid.position.y);

		float bounceY = rigid.position.y + bounce * Mathf.Sin (bounceSpeed * Time.deltaTime);
		rigid.position = new Vector3 (rigid.position.x,
	                           Mathf.Clamp (bounceY, 1, 4),
	                           rigid.position.z);
	}

	#endregion
}



