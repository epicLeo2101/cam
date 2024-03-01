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
