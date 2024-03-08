using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComputer : Interractable
{
    private GameObject showPressE;
    public MouseCursor mouseCursor;
    public PlayerMovement playerMovement;

    private void Start()
    {
        showPressE = GameObject.Find("Canvas");
        showPressE.SetActive(false);
    }

    public override void OnFocus()
    {
        showPressE.SetActive(true);
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        showPressE.SetActive(false);
        playerMovement.enabled = false;
        mouseCursor.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        print("Interacted with " + gameObject.name);
        //gameObject.layer = 0;
    }

    public override void OnLoseFocus()
    {
        showPressE.SetActive(false);
        print("Stop looking at " + gameObject.name);
    }
}
