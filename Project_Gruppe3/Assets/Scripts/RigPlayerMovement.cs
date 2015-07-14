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
	public AudioClip bams;
	public AudioClip bone;
	private AudioSource audioSrc;
//	private AudioSource audioSrc2;

	#endregion

	
	#region Unity event functions

	/// Use for initialization
	void Awake ()
	{
		capsule = GetComponent<CapsuleCollider> ();
		GetComponent<Rigidbody> ().freezeRotation = true;
		GetComponent<Rigidbody> ().useGravity = true;
	}

	/// Use this for initialization
	void Start ()
	{
		reallyPlayed = AddObject.bonusLevelStarted;
		//AddObject bonusRoom = obj.GetComponent<AddObject>();
		if (reallyPlayed) {

			GameObject[] names = GameObject.FindGameObjectsWithTag("bonusRoom");

			foreach(GameObject item in names){
				Debug.Log(item.ToString());
				Destroy(item);
			}

			currentPosAfterBonus = HoldInformations.GetPugCurrentPos();
			currentPosAfterBonus.y = currentPosAfterBonus.y + 10;
			Debug.Log("currentPosAfterBonus " + currentPosAfterBonus);
			GameObject.Find("NovaPug").transform.position = currentPosAfterBonus;
		}

		pug = GameObject.FindGameObjectWithTag ("fer");
		shotpoint = GameObject.FindGameObjectWithTag ("shotpoint");
	    audioSrc = GetComponent<AudioSource> ();
	}

	/// Update is called once per frame
	void Update ()
	{
		// Cache the input
		if (Input.GetMouseButtonDown (0))
			jumpFlag = true;
		if (Input.GetMouseButtonDown (1)) {
			ShootWithWater (bulletDistance);
		}

	}

	/// Update for physics
	void FixedUpdate ()
	{
		//Rotate field of view
		//++++++++++++++++++++ REPLACEMENT FOR EYETRACKING ++++++++++++++++++++
		if (Input.GetAxis ("Mouse X") < 0 || Input.GetAxis ("Mouse X") >= 0) {
			yRot += 2 * Input.GetAxis ("Mouse X");
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


	void OnTriggerEnter(Collider coll) {
		
		// Enemy hits Player --> Player gettin hurt
		if (coll.tag == "wool"){
			audioSrc.clip = bams;
			
			audioSrc.Play();
		}
		if (coll.tag == "bone"){
			audioSrc.clip = bone;
			
			audioSrc.Play();
		}
		if (coll.tag == "cat"){
			audioSrc.clip = bams;
			
			audioSrc.Play();
		}
		
	}


	#endregion
}
