using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfTriggered : MonoBehaviour {

    public bool isTriggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "rightHand")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "rightHand")
        {
            isTriggered = false;
        }
    }
}
