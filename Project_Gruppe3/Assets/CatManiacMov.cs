using UnityEngine;
using System.Collections;

public class CatManiacMov : MonoBehaviour {
	public float countdown = 4f;
	private Rigidbody rigid;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();

	
	}
	
	// Update is called once per frame
	public void FixedUpdate(){
		countdown -= Time.deltaTime;
		//if (countdown < 4.0f) {
		//	rigid.AddRelativeForce (Vector3.forward * 5F);
		//}
		
		if (countdown < 4F && countdown > 0.05F) {
			
			//	Debug.Log (rigid.rotation.y.ToString());
			//	Debug.Log (countdown.ToString()+"countdown");
			//rigid.AddRelativeForce (rigid.MoveRotation * 10.0F);
			rigid.AddRelativeForce (Vector3.forward * 4.0F);
			
			//  this.gameObject.transform.Rotate( 0.0F, 180F, 0.0F);
		}
		if(countdown<0.05F  && rigid.rotation.y <170F){
			this.gameObject.transform.Rotate( 0.0F, 180F, 0.0F);
			rigid.AddRelativeForce (Vector3.back * 4.0F);
			countdown=4.0F;
		}
	}
}
