using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interractable
{
    private bool Essential = false;
    private bool Death = false;

    private MeshRenderer objectApperance;
    private Light hoverLight;

    private void Start()
    {
        hoverLight = GetComponentInChildren<Light>();
        objectApperance = GetComponent<MeshRenderer>();

        //hoverLight.enabled = false;

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
        }
        if (objectApperance.enabled == false && Death == true)
        {
            GetComponent<Collider>().isTrigger = false;
            //hoverLight.enabled = false;
        }

        //---------------------------------------------------------- The one above 'death is the only thing that will run. ----------------------------------------

        if (objectApperance.enabled == false && Essential == true)
        {
            GetComponent<Collider>().isTrigger = true;
            //hoverLight.enabled = false;
        }
        if (objectApperance.enabled == true && Essential == true)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    public override void OnFocus()
    {
        hoverLight.enabled = true;
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        objectApperance.enabled = !objectApperance.enabled;
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        hoverLight.enabled = false;
        print("Stop looking at " + gameObject.name);
    }
}
