using UnityEngine;
using System.Collections;

public class BonesNoDeleting : MonoBehaviour
{
	#region Variables (public)
	
	public float speedForTheThrowUp;
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
		rigid.rotation = Quaternion.Euler(1f, 90f, 1F);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		MoveUpAndDown ();
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "pug") 
		{
			// if bullet collides with anything, destroy it
			Destroy (this.gameObject);
			GameObject.FindGameObjectWithTag("fer").GetComponent<Score>().score+=100;
			HoldInformations.SetScore(GameObject.FindGameObjectWithTag("fer").GetComponent<Score>().score);
		}
	}
	
	#endregion
	
	
	#region Methods
	
	void MoveUpAndDown(){
		
		float bounceY = rigid.position.y + bounce * Mathf.Sin (bounceSpeed * Time.deltaTime);
		rigid.position = new Vector3 (rigid.position.x,
		                              Mathf.Clamp (bounceY, rigid.position.y, rigid.position.y+3.0F),
		                              rigid.position.z);
	}
	
	#endregion
}



