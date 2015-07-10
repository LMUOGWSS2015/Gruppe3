using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
	
	#region Variables (public)
	
	public static bool isHurt = false;
	public GameObject dogsBone;
	//    public int numberOfObjects;
	public int numbOfObj;
	public float radius = 1f;
	//public RaycastHit hit;
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
	
	void Start(){
		
		player = GameObject.Find("Player");
		audio = GetComponent<AudioSource>();
		rigid = GetComponent<Rigidbody> ();
		//oneMoveToRight = new Vector3 (540, 285.72f, -67);
		position = rigid.position;
	//	Debug.Log (position);
	//	oneMoveToLeft = new Vector3 (540, 285.72f, -72);
		//forward = position+rigid.transform.forward * 2F;
	//	Debug.Log (forward.ToString ());

	}


	/// 








	//void Update () 
	//{    
	//	MoveUpAndDown ();
		/*LeftToRight ();

        if(Vector3.Distance(currentPosition, oneMoveToRight) < 0.5)
            this.transform.Rotate(0,180,0);

        RightToLeft ();*/
		
	//}
	
	
	void OnTriggerEnter (Collider coll){
		
		if (coll.tag == "fer"){
			
			Debug.Log("-1 life");
			isHurt = true;
			
			//pugLife.DecreaseLife();
			GameObject.FindGameObjectWithTag ("fer").GetComponent<PugLife>().DecreaseLife();
			
			///Blinking();
			audio.Play();
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
		
		//Vector3 startPosition = new Vector3 (transform.position.x + 0.01F,
		//                               transform.position.y + 5.2F,
		//                                 transform.position.z);
		//add velocity
		// Vector3 velocityChangeForShot = 1.02f * (startPosition);
		
		
		// spawn 1 kugel
		//    Instantiate (bulletSphere, velocityChangeForShot, transform.rotation);
		
		
		//Vector3 position = transform.position;
		// Clone the objects that are "in" the box.
		//        Vector3 offset = new Vector3 (1.1, 1, 1.5);
		//
		//        Vector3 position = new Vector3 (transform.position.x, transform.position.y + 6.0F, transform.position.z);
		//
		//        foreach (GameObject DogsBone in DogsBones)
		//        {
		//            if (DogsBone != null)
		//            {
		//                position=position*offset;
		//                Instantiate(DogsBone, position, Quaternion.identity);
		//            }
		//
		//        }
		//Vector3 position = new Vector3 (transform.position.x, transform.position.y + 6.0F, transform.position.z);
		
		//for (int i = 0; i < numbOfObj; i++) {
		//    float angle = i * Mathf.PI * 2.0F / numbOfObj;
		//    Vector3 position =new Vector3(Mathf.Cos (angle), 1.0F, Mathf.Sin (angle))*4.0F;
		
		//    Vector3 position = new Vector3((Mathf.Cos (angle)+startPosition.x)/4, 4.0F, ((Mathf.Sin(angle)+startPosition.z)/4)+1.0F);
		//Vector3 position = new Vector3(startPosition.x+i+2, 6+i, startPosition.z+);
		//(startPosition.x+i+2, 6+i, startPosition.z+i+2);
		//    Vector3 trajectory = UnityEngine.Random.insideUnitCircle*3F;
		//    Vector3 position = new Vector3(startPosition.x*i,startPosition.y+(i*2), startPosition.z);
		//    position+=trajectory;
		Instantiate (dogsBone, startPosition + (transform.right * (-6)) + (transform.up * 3), transform.rotation);
		Instantiate (dogsBone, startPosition + (transform.right * (-3)) + (transform.up * 3), transform.rotation);
		Debug.Log("dogsbohe" + dogsBone.transform.position);
		
		
		//Instantiate(dogsBone, position, transform.rotation);
		//Debug.Log (position.ToString());
	}
	
	//void MoveUpAndDown(){
		//Debug.Log (rigid.position.y);
		
		//float bounceY = rigid.position.y + 1.1 * Mathf.Sin (2 * Time.deltaTime);
		/*rigid.position = new Vector3 (rigid.position.x + 2,
                                      rigid.position.y,
                                      rigid.position.z + 2);*/
		///Vector3 position = rigid.position;
	//	Debug.Log (position.ToString());

	//	Vector3 positionForward = position+rigid.transform.forward * 2F;
	//	Vector3 positionBackward = position-rigid.transform.forward * 2F;
	///	Debug.Log (positionForward);
	//	var newPosition = Vector3.Lerp (position, positionForward, 100F);
	//	rigid.transform.position = newPosition;
	//	var newPosition2 = Vector3.Lerp (rigid.position, positionBackward, 100F);
	///	rigid.transform.position = newPosition2;




	//	rigid.position = Vector3.Lerp (rigid.position, 
	//		                              positionForward,
	//	                               Time.deltaTime*2.0F
	//	                               );
		//float bounceY = rigid.position.y + bounce * Mathf.Sin (bounceSpeed * Time.deltaTime);
		//rigid.position = new Vector3 (rigid.position.x,
///		                              Mathf.Clamp (bounceY, 1, 4),
//		                              rigid.position.z);
	//}
		//Debug.Log ("1");
		//rigid.transform.Rotate (0, 180, 0);
		//rigid.rotation = Quaternion.Euler(0.0f, 90F, 0.0f);
		//Debug.Log ("2");
	
	//float bounceX = rigid.position.x + 1 * Mathf.Sin (3 * Time.deltaTime);
	//float bounceZ = rigid.position.z + 1 * Mathf.Sin (3 * Time.deltaTime);


		//rigid.position = new Vector3 ( rigid.position.x,
		    //                          rigid.position.y,
		//                              Mathf.Clamp (bounceZ , position.z, position.z*1.2));         

	//}
	
	/*IEnumerator MoveUpAndDown()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            rigid.transform.position = Vector3.Lerp(rigid.transform.position, oneMoveToRight, timeSinceStarted);
            
            // If the object has arrived, stop the coroutine
            if (rigid.position == oneMoveToRight)
            {
                yield break;
            }
            
            // Otherwise, continue next frame
            yield return null;
        }
    }*/
	
	/*private void LeftToRight() {
        //the speed, in units per second, we want to move towards the target
        float speed = 1;
        //move towards the center of the world (or where ever you like)
        //Vector3 targetPosition = new Vector3(0,0,0);
        
        currentPosition2 = currentPosition;
        //first, check to see if we're close enough to the target
        if(Vector3.Distance(currentPosition, oneMoveToRight) > .1f) { 
            Vector3 directionOfTravel = oneMoveToRight - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }

    }

    /*private void RightToLeft() {
        //the speed, in units per second, we want to move towards the target
        float speed = 1;
        //move towards the center of the world (or where ever you like)
        //Vector3 targetPosition = new Vector3(0,0,0);
        
        currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if(Vector3.Distance(currentPosition2, oneMoveToLeft) > .1f) { 
            Vector3 directionOfTravel = oneMoveToRight - currentPosition;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components
            
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
        
    }*/
	
	
	
	/*void Blinking(){

        if (Time.time > timer) {
            
            timer = Time.time + .4;
            onoff = !onoff;
            player.GetComponent<Renderer> ().enabled = onoff;
        }
    }*/
	
	#endregion
}