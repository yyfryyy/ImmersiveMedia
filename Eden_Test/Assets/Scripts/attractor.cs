using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour {

	public Rigidbody rbToAttract;
	Vector3 direction;
	public int m = 100;



	void FixedUpdate() {
		direction = gameObject.transform.position - rbToAttract.position;

		float dist = direction.magnitude;
		Debug.Log (dist);
		if (rbToAttract.velocity.magnitude < 0.7f && dist < 1) {
		} else {
			attract ();
		}
	}

	void attract() {
	
		direction = gameObject.transform.position - rbToAttract.position;
		float dist = direction.magnitude;
		float forceMagnitude = (m * rbToAttract.mass) / Mathf.Pow (dist, 2);
		forceMagnitude = Mathf.Clamp (forceMagnitude,0,100);
		Vector3 force = direction.normalized * forceMagnitude;
		Debug.Log ("Force"+rbToAttract.velocity.magnitude);
		rbToAttract.AddForce (force);
        rbToAttract.AddForce(new Vector3(0, -9.81f, 0));
		rbToAttract.transform.Rotate (Vector3.right*01);

	}

}
