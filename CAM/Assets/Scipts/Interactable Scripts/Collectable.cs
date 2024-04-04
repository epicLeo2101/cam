using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interractable
{
    DontDestroy dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = GameObject.FindGameObjectWithTag("Unlocks&Collectables").GetComponent<DontDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        dontDestroy.UnlockedDocumentIcon1();
        Destroy(gameObject);
        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }
}
