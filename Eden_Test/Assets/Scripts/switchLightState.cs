using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchLightState : MonoBehaviour {


    public Collider hand;
    bool lightState = false;
    public GameObject armband;
    public Material material;




    // Use this for initialization
    void Start()
    {
        //material = armband.GetComponent<Material>();
        gameObject.GetComponent<Light>().enabled = lightState;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.GetComponent<Light>().enabled = lightState;


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other == hand)
        {

            lightState = !lightState;
            gameObject.GetComponent<Light>().enabled = lightState;

            if(lightState)
            {
                material.SetColor("_EmissionColor", Color.white);
            }
            else
            {
                material.SetColor("_EmissionColor", Color.black);
            }

        }
    }
    

}
