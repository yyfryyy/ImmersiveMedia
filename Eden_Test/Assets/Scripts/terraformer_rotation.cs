using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terraformer_rotation : MonoBehaviour {

	public bool inverse = false;
	public int speed = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!inverse) {
			transform.Rotate (Vector3.up * speed * Time.deltaTime, Space.Self);
		} else {
			transform.Rotate (Vector3.down*speed*Time.deltaTime,Space.Self) ;
		}
	}
}
