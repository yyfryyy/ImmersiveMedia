using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attract2 : MonoBehaviour {

    public Rigidbody rbToAttract;
    Vector3 direction;
    public int m = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        direction = transform.position - rbToAttract.transform.position;
        float dist = direction.magnitude;
        direction = direction.normalized;
        float forceMagnitude = (m * rbToAttract.mass) / Mathf.Pow(dist, 1);
        forceMagnitude = Mathf.Clamp(forceMagnitude, 0, 100);
        Vector3 force = forceMagnitude * direction;
        if (dist < 0.04f)
        {
            rbToAttract.velocity = new Vector3(0, 0, 0);
            rbToAttract.isKinematic = true;
            rbToAttract.transform.Rotate(Vector3.up,Space.World);
        }
        else
        {
            rbToAttract.AddForce(force);
        }
	}
}
