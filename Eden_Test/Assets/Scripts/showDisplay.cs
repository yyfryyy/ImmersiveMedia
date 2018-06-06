using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showDisplay : MonoBehaviour {

    Vector3 dirHand;
    Vector3 dirCamera;
    public GameObject Camera;
    float dotProduct;
    public GameObject UI;
    Canvas UIcanvas;
    public GameObject ScannedObject;
    public bool showing;
    scanner scanner;
    public GameObject rightHand;
    OVRGrabber grabScript;
    OVRGrabbable grabbableScript;
    public checkIfTriggered checkTrigger;


    public Text MaterialText;
    public Text GewichtText;
    public Text DichteText;
    public Text AlterText;

    // Use this for initialization
    void Start()
    {
        UIcanvas = UI.GetComponent<Canvas>();
        scanner = GetComponent<scanner>();
        grabScript = rightHand.GetComponent<OVRGrabber>();
    }
	
	// Update is called once per frame
	void Update () {
        dirHand = transform.up;
        dirCamera = Camera.transform.forward;
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + transform.up, Color.red);
        Debug.DrawLine(Camera.transform.position, Camera.transform.position + Camera.transform.forward, Color.blue);
        dotProduct = Vector3.Dot(dirCamera.normalized, dirHand.normalized);
        //Debug.Log(dotProduct);

        if (checkTrigger.isTriggered == false)
        {

            if (gameObject.GetComponent<OVRGrabber>().grabbedObject == null)
            {

                if (dotProduct > 0.8f)
                {
                    UI.SetActive(true);
                    Debug.Log("Show UI");
                    if (ScannedObject)
                    {
                        ScannedObject.GetComponent<Renderer>().enabled = true;
                        ScannedObject.GetComponent<OVRGrabbable>().enabled = true;
                        showing = true;
                    }
                }
                else
                {

                    Debug.Log("Hide UI");
                    //Debug.Log(grabScript.grabbedObject.isGrabbed);
                    //&& grabScript.grabbedObject.isGrabbed == false
                    if (ScannedObject)
                    {
                        //grabbableScript = ScannedObject.GetComponent<OVRGrabbable>();
                        //if (grabbableScript.isGrabbed == false)
                        //{
                        MaterialText.text = "---";
                        GewichtText.text = "---";
                        DichteText.text = "---";
                        AlterText.text = "---";
                        //ScannedObject.transform.parent = null;

                        if (ScannedObject.GetComponent<OVRGrabbable>().isGrabbed == false && ScannedObject && ScannedObject.GetComponent<properties>().gettingScanned == true)
                        {
                            //ScannedObject.GetComponent<Rigidbody>().isKinematic = false;
                            showing = true;
                            //ScannedObject.GetComponent<properties>().gettingScanned = false;
                            UI.SetActive(true);
                            //ScannedObject.transform.parent = null;
                            //ScannedObject = null;

                        }

                        if (ScannedObject.GetComponent<OVRGrabbable>().isGrabbed == true)
                        {
                            ScannedObject = null;
                        }
                        //ScannedObject.GetComponent<OVRGrabbable>().enabled = false;
                        //ScannedObject.GetComponent<Renderer>().enabled = false;
                        //showing = false;
                        //}
                    }
                    else if (!ScannedObject)
                    {
                        if (rightHand.GetComponent<OVRGrabber>().grabbedObject == null)
                        {
                            UI.SetActive(false);
                        }

                    }
                }
            }
        }
    }


}
