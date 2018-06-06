using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepColliderOn : MonoBehaviour {

    Collider col;
	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        col.enabled = true;
    }
}
