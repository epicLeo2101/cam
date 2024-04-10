using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interractable
{
    private MeshRenderer objectApperance;

    private void Start()
    {
        objectApperance = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (objectApperance.enabled == true)
        {
            GetComponent<Collider>().isTrigger = true;
        }
        if (objectApperance.enabled == false)
        {
            GetComponent<Collider>().isTrigger = false;
        }
    }

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        objectApperance.enabled = !objectApperance.enabled;
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }
}
