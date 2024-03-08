using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablePhysics : Interractable
{
    public GameObject disappearingObject;

    //private void Start()
    //{
    //}

    //private void Update()
    //{

    //}

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        disappearingObject.SetActive(false);
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }
}
