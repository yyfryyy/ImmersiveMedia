using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class properties : MonoBehaviour {


    public string material = "Holz";
    public float gewicht = 2;
    public float dichte = 2;
    public float alter = 2000;
    public bool gettingScanned = false;
    Renderer rend;
    //public Material GlowingMaterial;
    //static Material[] materials;
    //static Material[] materialsBackUp;

    //private bool madeBackUp = false;

    //MeshRenderer mesh;

    bool scaled = false;
    public float scaleFactor = 1;
    [Range(min:0,max:3)]
    public int rotationDirection = 0;

    // Use this for initialization
    void Start()
    {
        //rend = gameObject.GetComponent<Renderer>();
        //mesh = gameObject.GetComponent<MeshRenderer>();
        gameObject.tag = "scannable";
        //materialsBackUp = rend.materials;

        //for (int i = 0; i < materialsBackUp.Length; i++)
        //{
        //    Debug.Log(materialsBackUp[i]);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (gettingScanned)
        {
            if (!scaled)
            {
                gameObject.transform.localScale *= scaleFactor;
                scaled = true;
                gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);
            }
            //materials = rend.materials;
            //if (!madeBackUp)
            //{
            //    materialsBackUp = materials;
            //    madeBackUp = true;
            //}

            //for (int i = 0; i < materials.Length; i++)
            //{
            //    materials[i] = GlowingMaterial;


            //    //Debug.Log("Materialname: " + materials[i].name);
            //    //if (materials[i].name == "Glow (Instance)")
            //    //{
            //    //    Debug.Log("Drinnen!!!!!!!!!!!!!!");
            //    //    materials[i].SetColor("_TintColor", Color.white);
            //    //}
            //}
            //GetComponent<Renderer>().materials = materials;

            if (rotationDirection == 0)
            {
                transform.Rotate(Vector3.right, Space.World);
            }
            else if (rotationDirection == 1)
            {
                transform.Rotate(Vector3.left, Space.World);
            }
            else if (rotationDirection == 2)
            {
                transform.Rotate(Vector3.up, Space.World);
            }
            else if (rotationDirection == 3)
            {
                transform.Rotate(Vector3.down, Space.World);
            }
        }

        else if (!gettingScanned)
        {

            if (scaled)
            {
                gameObject.transform.localScale /= scaleFactor;
                scaled = false;
            }
            //materials = GetComponent<Renderer>().materials;
            //if (!madeBackUp)
            //{
            //    materialsBackUp = GetComponent<Renderer>().materials;
            //    madeBackUp = true;
            //}

            //for (int n = 0; n<materialsBackUp.Length; n++)
            //{
            //    materials[n] = materialsBackUp[n];
            //}
            //    materials = materialsBackUp;

            //Debug.Log(materialsBackUp);
            //GetComponent<Renderer>().materials = materials;

            //for (int i = 0; i < materials.Length; i++)
            //{
            //    materials[i] = materialsBackUp[i];
            //    //if (materials[i].name == "Glow (Instance)")
            //    //{
            //    //    Debug.Log("machs wieder schwarz!");
            //    //    materials[i].SetColor("_TintColor", Color.black);
            //    //}
            //}
        }
    }
}
