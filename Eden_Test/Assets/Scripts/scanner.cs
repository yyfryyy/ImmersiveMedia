using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scanner : MonoBehaviour {

    Rigidbody rb;
    public bool snapped = false;
    GameObject snappedObject;
    public GameObject UI;
    showDisplay showScript;
    public GameObject Grabber;
    OVRGrabber grabberScript;
    properties props;
    public bool triggered = false;

    public Text MaterialText;
    public Text GewichtText;
    public Text DichteText;
    public Text AlterText;

    bool positionSnapped = false;






    // Use this for initialization
    void Start () {
        showScript = UI.GetComponent<showDisplay>();
        grabberScript = Grabber.GetComponent<OVRGrabber>();
	}
	
	// Update is called once per frame
	void Update () {

        /*   if (grabberScript.grabbedObject == snappedObject)
           {

               snapped = false;
               //snappedObject.GetComponentInParent<Rigidbody>().isKinematic = false;
               snappedObject = null;
               showScript.ScannedObject = null;

           }
               */
               if (!snapped)
        {
            //showScript.ScannedObject = null;
        }
    }



    private void OnTriggerStay(Collider other)
    {

            if (other.transform.tag == "scannable" && grabberScript.grabbedObject == null)
            {
            other.GetComponentInParent<Rigidbody>().isKinematic = true;
            //other.transform.position = transform.position;
            other.transform.SetParent(gameObject.transform);

            if (!positionSnapped)
            {
                other.transform.position = gameObject.transform.position;
            }

            snappedObject = other.gameObject;
            snapped = true;
            //Debug.Log("Snap");
            showScript.ScannedObject = snappedObject;
            props = snappedObject.GetComponent<properties>();
            props.gettingScanned = true;

            Debug.Log("Material: " + props.material);
            Debug.Log("Gewicht: " + props.gewicht + "kg");
            Debug.Log("Dichte: " + props.dichte +"g/cm3");
            Debug.Log("Jahre: " + props.alter + " Jahre");

            MaterialText.text = props.material;
            GewichtText.text =props.gewicht.ToString() + "kg";
            DichteText.text = props.dichte.ToString() + "g/cm3";
            AlterText.text = props.alter.ToString() + " Jahre";

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "scannable")
        {
            //other.GetComponentInParent<Rigidbody>().isKinematic = false;
            if (snappedObject && showScript.showing)
            {
                snappedObject.transform.parent = null;
            }
            snappedObject = null;
            snapped = false;
            if (other == null)
            {
                props.gettingScanned = false;
            }
            props.gettingScanned = false;

            MaterialText.text = "---";
            GewichtText.text = "---";
            DichteText.text = "---";
            AlterText.text = "---";

        }
    }


}
