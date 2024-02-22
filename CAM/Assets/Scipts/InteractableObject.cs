using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interractable
{

    private void Start()
    {
    }

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }
}
