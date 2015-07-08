using UnityEngine;
using System.Collections;

public class HelmetSpawnManager : MonoBehaviour
{

#region Variables (public)
		
public GameObject Helmet;

		
#endregion
		
		
#region Variables (private)
		
private GameObject pug;
		
#endregion
		
		
#region Unity event functions
		
	void Update ()
	{
		// Get all Spawning Points
		pug = GameObject.FindGameObjectWithTag ("fer");

		float distance = Vector3.Distance (this.gameObject.transform.position, pug.transform.position);
		if (distance < 20f) {
			CreateHelmet ();
			Destroy (this.gameObject);
		}
	}
		
		#endregion
		
		
		#region Methods
		
	void CreateHelmet ()
	{
			
		// Creatin enemy infront of the player's view
		Instantiate (Helmet, 
			            pug.transform.position + pug.transform.forward * 30f,
			            new Quaternion (0.0f, pug.transform.rotation.y, 0.0f, pug.transform.rotation.w));
	}
		
		#endregion
}
	
	
	
	
