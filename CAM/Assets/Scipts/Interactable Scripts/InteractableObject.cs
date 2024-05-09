using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interractable
{
    private bool Essential = false;
    private bool Death = false;

    private MeshRenderer objectApperance;

    public GameObject Hologram;

    private void Start()
    {
        objectApperance = GetComponent<MeshRenderer>();


        if (this.tag == "Essential")
        {
            Essential = true;
        }

        if (this.tag == "Death")
        {
            Death = true;
        }
    }

    private void Update()
    {
        if (objectApperance.enabled == true && Death == true)
        {
            GetComponent<Collider>().isTrigger = true;
            //Hologram.SetActive(false);
        }
        if (objectApperance.enabled == false && Death == true)
        {
            GetComponent<Collider>().isTrigger = false;
            //Hologram.SetActive(true);
        }

        //---------------------------------------------------------- The one above 'death is the only thing that will run. ----------------------------------------

        if (objectApperance.enabled == false && Essential == true)
        {
            GetComponent<Collider>().isTrigger = true;
            //Hologram.SetActive(true);
        }
        if (objectApperance.enabled == true && Essential == true)
        {
            GetComponent<Collider>().isTrigger = false;
            //Hologram.SetActive(false);
        }
    }

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        objectApperance.enabled = !objectApperance.enabled;
        Hologram.SetActive(!Hologram.activeSelf);
        
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }
}
