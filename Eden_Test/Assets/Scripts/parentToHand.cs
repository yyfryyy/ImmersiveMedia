using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentToHand : MonoBehaviour {

    public GameObject hand;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        //offset = hand.transform.position-gameObject.transform.position;
        gameObject.transform.SetParent(hand.transform);
    }
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.position = hand.transform.position -offset;
	}
}
