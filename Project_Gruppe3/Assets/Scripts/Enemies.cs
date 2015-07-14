using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
	
	#region Variables (public)
	
	public static bool isHurt = false;
	public GameObject dogsBone;
	public int numbOfObj;
	public float radius = 1f;
	Vector3 startPosition;
	public  double timer;
	public bool onoff;
	Vector3 oneMoveToRight;
	Vector3 oneMoveToLeft;
	Vector3 currentPosition;
	Vector3 currentPosition2;
	
	#endregion
	
	
	#region Variables (private)
	
	private GameObject player; 
	private AudioSource audio;
	private Rigidbody rigid;
	private Vector3 position;
	private Vector3 forward;

	
	#endregion
	
	
	#region Methods
	
	/*void OnTriggerEnter (Collider col){

        // Enemy hits Player --> Player gettin hurt


            
            /*ContactPoint contact = col.contacts [0];
            //startPosition = contact.point;
            Debug.Log (startPosition.ToString () + col.gameObject.ToString ());
            Debug.Log (col.gameObject.ToString ());*/
	
	//}
	
	void Start()
	{
		
		player = GameObject.Find("Player");
		audio = GetComponent<AudioSource>();
		rigid = GetComponent<Rigidbody> ();
		//oneMoveToRight = new Vector3 (540, 285.72f, -67);
		position = rigid.position;
	}


	void OnTriggerEnter (Collider coll){
		
		if (coll.tag == "fer"){
			
			Debug.Log("-1 life");
			isHurt = true;

			GameObject.FindGameObjectWithTag ("fer").GetComponent<PugLife>().DecreaseLife();
			Destroy (this.gameObject);
		}
		
		// if Enemy collides with the Bullet (waterDrop), destroy it itself
		if (coll.gameObject.tag == "waterDrop") {
			
			startPosition = coll.transform.position;
			// run destruction function
			Destroy (this.gameObject);
			
			SpawnDogBones ();
			
			// Adding score points for killing an enemy
			GameObject.FindGameObjectWithTag ("fer").GetComponent<Score> ().score += 100;
			HoldInformations.SetScore(GameObject.FindGameObjectWithTag ("fer").GetComponent<Score> ().score);
			
		} 
	}
	
	void SpawnDogBones (){

		Instantiate (dogsBone, startPosition + (transform.right * (-6)) + (transform.up * 3), transform.rotation);
		Instantiate (dogsBone, startPosition + (transform.right * (-3)) + (transform.up * 3), transform.rotation);
		Debug.Log("dogsbohe" + dogsBone.transform.position);
	}

	#endregion
}