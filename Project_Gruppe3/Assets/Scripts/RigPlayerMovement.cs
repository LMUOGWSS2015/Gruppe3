/*using UnityEngine;
using System.Collections;

public class RigPlayerMovement : MonoBehaviour {
	public bool invertYAxis;
	public float boundsWidth;
	public float boundsHeight;
	public float speed;
	public float tilt;
	public float bounce;
	public float bounceSpeed;
	public float yRot;
	public float kilo;	
	public float gravity = 40;
	//public GameObject bullet;
	//public AudioClip audioBullet;
	//public float fireDistance;
	//public GameObject explosion;
	//public AudioClip audioExplosion;
	//public float volume = 0.1f;
		
	private Vector3 defaultPos;
	private float inputHorizontal;
	private float inputVertical;
	private float seconds;
		
	private Rigidbody rigid;
	//private AudioSource audioSrc;
	//private Renderer rend;
	private Collider col;

	void Start ()

		/// <summary>
		/// @ZENIB!!! Bitte den auskommentierten Code nicht löschen, es gibt vieles was noch nicht zu Ende gedacht ist und noch im Arbeitsstadium steckt.
		/// Außerdem ist im Inspektor die "Rotation" für alle drei Achsen ausgeclickt -> ansonsten bewegt sich der Spieler der Spirale entlang.
		/// Das heisst aber nicht dass wir den Charakter nicht routieren können. Das geht dann mit rigid.rotate oder so:) diese häckchen verhindern nur, dass bei der Kollision es dazu kommt, dass Objekt willkürlich 
		/// routiert.
		/// Jump-Funktion ist mir immer noch nicht gelungen. auch mit gravity und extra gravity und zusätzliche Masse(im inspektor unter Rigidbody Mass oder auch im Code)
		/// Danke für die Aufmerksamkeit:)
		/// 
		/// </summary>
	{
			// cache components
		rigid = GetComponent<Rigidbody>();
		//rigid.mass = kilo;
		//audioSrc = GetComponent<AudioSource>();
		//rend = GetComponent<Renderer>();
		col = GetComponent<Collider>();
			
			// fetch default position from our inspector
		defaultPos = transform.position;
	}
		
	void Update ()
	{
			// grabs input in update loop for best accuracy
		PlayerInput();

			
		// based on game states, do something...
		//GameStates gameState = GameController.gameState;
		//if (gameState == GameStates.GamePlay)
		//	{
				// disable renderer and collider
		//	if (!rend.enabled) rend.enabled = true;
		//	if (!col.enabled) col.enabled = true;
				
				// fire button triggers bullets (space bar)
		//if (Input.GetButtonDown("Jump"))
		///	{
					// handles bullet firing
		//		Fire(fireDistance);
		//	}
		//}
		//else
		//{
				// disable renderer and collider
		//	if (rend.enabled) rend.enabled = false;
		//	if (col.enabled) col.enabled = false;
			// reset player position to default
			//transform.position = defaultPos;
		//	}



		}
		
	void FixedUpdate ()
	{
			// run movement function to handle rigidbody physics
		ApplyGravity ();
		Movement();
	}
		
	void PlayerInput()
	{
	// fetch our input for movememnt
		inputHorizontal = Input.GetAxis("Horizontal");
		inputVertical = Input.GetAxis("Vertical");
		Debug.Log (inputHorizontal + " und " + inputVertical);	
		if (invertYAxis)
		{
			inputVertical *= -1;
		}
		if (Input.GetAxis ("Mouse X") < 0 || Input.GetAxis ("Mouse X") >= 0) {
			yRot += 10 * Input.GetAxis ("Mouse X");
		}
		if(Input.GetMouseButtonDown(0))
			Jump();
		if(Input.GetMouseButtonDown(1))
			Debug.Log("Bang Bang for shooting later"); 
	}
		
	void Movement()
	{
		// update player velocity
		Vector3 input = new Vector3(inputHorizontal, 0.0f, inputVertical);
		rigid.velocity = input * speed;
			
		// create a hover effect using a sin wave
		///float bounceY = rigid.position.y + bounce * Mathf.Sin(bounceSpeed * Time.time);
			
		// apply hover effect, and clamp player within bounds
		//rigid.position = new Vector3 (rigid.position.x * inputVertical * speed * Time.deltaTime, rigid.position.y, rigid.position.z * inputHorizontal * speed * Time.deltaTime);
		                         
		rigid.AddForce (speed*inputHorizontal, 0.0f, speed*inputVertical, ForceMode.Acceleration); 	                         
		//rigid.position.z
		//m_MouseLook.LookRotation (transform, m_Camera.transform);
			
			// apply tilt effect to our rotation
		//float tiltX = rigid.velocity.y * -tilt;
	//	float tiltZ = rigid.velocity.x * -tilt;
	///@Ina die nächsten zeilen für wellenartige bewegung adaptieren 
		//float bounceY = rigid.position.y + bounce * Mathf.Sin(bounceSpeed * Time.time);
		//rigid.position = new Vector3(rigid.position.x,
		  //                           Mathf.Clamp(bounceY, -boundsHeight, boundsHeight),
		  //                           rigid.position.z);
	
		rigid.rotation = Quaternion.Euler(0.0f, yRot, 0.0f);





		

		//rigid.rotation = Quaternion.Euler (rigid.velocity.x*-tilt, 0.0f, rigid.velocity.z * -tilt);
//		if (Input.GetKey(KeyRight))
//		{
//			rigid.AddForce(Vector3.right * speed);
//		}
//		if (Input.GetKey(KeyLeft))
//		{
//			rigidbody.AddForce(Vector3.left * Speed, Mode);
//		}
	}

	void Jump(){
		rigid.AddForce (0.0f, 500.0f, 0.0f, ForceMode.Impulse); 
		//rigid.velocity.y = 20;
	}








	void ApplyGravity(){
		if (rigid.velocity.magnitude > 0.1) {
			rigid.velocity = new Vector3(0.0f, -gravity * Time.deltaTime, 0.0f);
				//
		}
	}











		
//	void Fire (float distance)
//	{
//			// play bullet-fire sound
//		audioSrc.clip = audioBullet;
//		audioSrc.volume = volume * 0.5f; // multiplying it by 50% because effect iss still too loud...
//		audioSrc.Play();
//			
//			// define left firing position, add distance to spawn ahead of player
//		Vector3 fireFromLeft = new Vector3(transform.position.x - distance,
//		                                   transform.position.y,
//		                                   transform.position.z + distance);
//			
//		// define right firing position, add distance to spawn ahead of player
//		Vector3 fireFromRight = new Vector3(transform.position.x + distance,
//		                                    transform.position.y,
//		                                    transform.position.z + distance);
//			
//		// spawn 2 bullets
//		Instantiate(bullet, fireFromLeft, transform.rotation);
//		Instantiate(bullet, fireFromRight, transform.rotation);
//	}

	void Destruction()
	{
			// play destruction sound
//		audioSrc.clip = audioExplosion;
//		audioSrc.volume = volume;
//		audioSrc.Play();
//			
		// spawn an explosion effect
	//	Instantiate(explosion, transform.position, transform.rotation);
			
		// change game state to game over
	//	GameController.gameState = GameStates.GameOver;
	//	GameController.changeState = true;
		Debug.Log ("bla");
	}
		
	void OnTriggerEnter(Collider coll)
		{
			// if player collides with a danger object...
		if (coll.gameObject.tag == "Spheres")
		{
			// run destruction function
				Destruction();
		}
		}
	}*/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class RigPlayerMovement : MonoBehaviour
{
	#region Variables (private)
	
	private bool grounded = false;
	private Vector3 groundVelocity;
	private CapsuleCollider capsule;
	private float yRot;
	private GameObject pug;
	private GameObject shotpoint;
	
	// Inputs Cache
	private bool jumpFlag = false;

	private static bool reallyPlayed;
	private Vector3 currentPosAfterBonus;
	
	#endregion
	
	#region Properties (public)
	
	// Speeds
	public float walkSpeed=4.0F;
	public float walkBackwardSpeed = 1.0f;
	public float runSpeed=6.0F;
	public float runBackwardSpeed = 3.0f;
	public float sidestepSpeed = 3.0f;
	public float runSidestepSpeed = 3.0f;
	public float maxVelocityChange = 2.0f;

	
	// Air
	public float inAirControl = 0.1f;
	public float jumpHeight = 2.0f;
	
	// Can Flags
	public bool canRunSidestep = true;
	public bool canJump = true;
	public bool canRun = true;

	//Bullet-Sphere-Object
	public GameObject bulletSphere;
	public float bulletDistance;

	public int helmet = 0;
    public AudioClip pew;
	public AudioClip steam;
	private AudioSource audioSrc;
//	private AudioSource audioSrc2;

	#endregion

	
	#region Unity event functions
	
	/// <summary>
	/// Use for initialization
	/// </summary>
	void Awake ()
	{
		capsule = GetComponent<CapsuleCollider> ();
		GetComponent<Rigidbody> ().freezeRotation = true;
		GetComponent<Rigidbody> ().useGravity = true;
	}
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start ()
	{
		reallyPlayed = AddObject.bonusLevelStarted;
		//AddObject bonusRoom = obj.GetComponent<AddObject>();
		if (reallyPlayed) {

			GameObject[] names = GameObject.FindGameObjectsWithTag("bonusRoom");
			//Destroy(GameObject.FindGameObjectsWithTag("bonusRoom"));
			//Destroy(names);
			
			
			foreach(GameObject item in names){
				Debug.Log(item.ToString());
				Destroy(item);
			}

			currentPosAfterBonus = HoldInformations.GetPugCurrentPos();
			currentPosAfterBonus.x = currentPosAfterBonus.x - 10;
			Debug.Log("currentPosAfterBonus " + currentPosAfterBonus);
			GameObject.Find("NovaPug").transform.position = currentPosAfterBonus;

		}

		pug = GameObject.FindGameObjectWithTag ("fer");
		shotpoint = GameObject.FindGameObjectWithTag ("shotpoint");
	    audioSrc = GetComponent<AudioSource> ();
		///musicToShot = Resources.Load ("Sounds/pew");
	//	musicToShot = Resources.Load ("Sounds/pew") as AudioClip;

	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update ()
	{
		// Cache the input
		if (Input.GetMouseButtonDown (0))
			jumpFlag = true;
		if (Input.GetMouseButtonDown (1)) {
			ShootWithWater (bulletDistance);
		}

	}
	
	/// <summary>
	/// Update for physics
	/// </summary>
	void FixedUpdate ()
	{
		//Rotate field of view
		//++++++++++++++++++++ REPLACEMENT FOR EYETRACKING ++++++++++++++++++++
		if (Input.GetAxis ("Mouse X") < 0 || Input.GetAxis ("Mouse X") >= 0) {
			yRot += 10 * Input.GetAxis ("Mouse X");
		}
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, yRot, 0.0f);

		// Cache de input
		var inputVector = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		
		// On the ground
		if (grounded) {
			// Apply a force that attempts to reach our target velocity
			var velocityChange = CalculateVelocityChange (inputVector);
			GetComponent<Rigidbody> ().AddForce (velocityChange, ForceMode.VelocityChange);
			
			// Jump
			if (canJump && jumpFlag) {

				//audioSrc.volume = volume * 0.5f; // multiplying it by 50% because effect iss still too loud...
				//audioSrc.Play();
				audioSrc.clip = steam;
				jumpFlag = false;
				audioSrc.Play();
				GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, GetComponent<Rigidbody> ().velocity.y + CalculateJumpVerticalSpeed (), GetComponent<Rigidbody> ().velocity.z);
			}
			
			// By setting the grounded to false in every FixedUpdate we avoid
			// checking if the character is not grounded on OnCollisionExit()
			grounded = false;
		}
		// In mid-air
		else {
			// Uses the input vector to affect the mid air direction
			var velocityChange = transform.TransformDirection (inputVector) * inAirControl;

			GetComponent<Rigidbody> ().AddForce (velocityChange, ForceMode.VelocityChange);
		}
		if (helmet > 0) {
			Debug.Log (helmet);
		}
	}

	void  ShootWithWater (float sphereDistance)
	{

		//audioSrc2.clip (musicToShot);

		audioSrc.clip = pew;
		audioSrc.Play();
		Vector3 startPosition = new Vector3 (transform.position.x,
		                                     transform.position.y,
		                                     transform.position.z);
		float distance = Vector3.Distance (shotpoint.transform.position, pug.transform.position);

		Vector3 velocityChangeForShot = 1.01F*(startPosition);


		// spawn 1 kugel
		Instantiate (bulletSphere, startPosition+  shotpoint.transform.forward*1.6F, shotpoint.transform.rotation);

		//Instantiate (bulletSphere, 
		  //         velocityChangeForShot + shotpoint.transform.forward*1F,
		    //       new Quaternion (0.0f, shotpoint.transform.rotation.y, 0.0f, shotpoint.transform.rotation.w));
	}


	// Unparent if we are no longer standing on our parent
	void OnCollisionExit (Collision collision)
	{
		if (collision.transform == transform.parent)
			transform.parent = null;
	}
	
	// If there are collisions check if the character is grounded
	void OnCollisionStay (Collision col)
	{
		TrackGrounded (col);
	}
	
	void OnCollisionEnter (Collision col)
	{
		TrackGrounded (col);
	}
	
	#endregion
	
	#region Methods
	
	// From the user input calculate using the set up speeds the velocity change
	private Vector3 CalculateVelocityChange (Vector3 inputVector)
	{
		// Calculate how fast we should be moving
		var relativeVelocity = transform.TransformDirection (inputVector);
		if (inputVector.z > 0) {
			relativeVelocity.z *= (canRun && Input.GetButton ("Jump")) ? runSpeed : walkSpeed;
		} else {
			relativeVelocity.z *= (canRun && Input.GetButton ("Jump")) ? runBackwardSpeed : walkBackwardSpeed;
		}
		relativeVelocity.x *= (canRunSidestep && Input.GetButton ("Jump")) ? runSidestepSpeed : sidestepSpeed;
		
		// Calcualte the delta velocity
		var currRelativeVelocity = GetComponent<Rigidbody> ().velocity - groundVelocity;
		var velocityChange = relativeVelocity - currRelativeVelocity;
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		
		return velocityChange;
	}
	
	// From the jump height and gravity we deduce the upwards speed for the character to reach at the apex.
	private float CalculateJumpVerticalSpeed ()
	{
		return Mathf.Sqrt (2f * jumpHeight * Mathf.Abs (Physics.gravity.y));
	}
	
	// Check if the base of the capsule is colliding to track if it's grounded
	private void TrackGrounded (Collision collision)
	{
		var maxHeight = capsule.bounds.min.y + capsule.radius * .9f;
		foreach (var contact in collision.contacts) {
			if (contact.point.y < maxHeight) {
				if (isKinematic (collision)) {
					// Get the ground velocity and we parent to it
					groundVelocity = collision.rigidbody.velocity;
					transform.parent = collision.transform;
				} else if (isStatic (collision)) {
					// Just parent to it since it's static
					transform.parent = collision.transform;
				} else {
					// We are standing over a dinamic object,
					// set the groundVelocity to Zero to avoid jiggers and extreme accelerations
					groundVelocity = Vector3.zero;
				}
				grounded = true;
			}
			break;
		}
	}
	
	private bool isKinematic (Collision collision)
	{
		return isKinematic (GetComponent<Collider> ().transform);
	}
	
	private bool isKinematic (Transform transform)
	{
		return transform.GetComponent<Rigidbody> () && transform.GetComponent<Rigidbody> ().isKinematic;
	}
	
	private bool isStatic (Collision collision)
	{
		return isStatic (collision.transform);
	}
	
	private bool isStatic (Transform transform)
	{
		return transform.gameObject.isStatic;
	}


	#endregion
}
