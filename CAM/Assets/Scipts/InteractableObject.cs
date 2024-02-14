using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interractable
{
    private GameObject pressE;

    private void Start()
    {
        pressE = GameObject.Find("Canvas");
        pressE.SetActive(false);
    }

    public override void OnFocus()
    {
        pressE.SetActive(true);
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        pressE.SetActive(false);
        print("Stop looking at " + gameObject.name);
    }
}
