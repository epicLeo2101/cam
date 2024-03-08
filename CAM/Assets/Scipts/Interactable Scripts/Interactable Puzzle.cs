using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractablePuzzle : Interractable
{
    //private bool coroutineAllowed;        <<<<<<-------------- This is somthing for a puzzle involving rotation. Put in the back burner for now.

    private void Start()
    {
        //coroutineAllowed = true;
    }

    //private void Update()
    //{

    //}

    public override void OnFocus()
    {
        print("Looking at " + gameObject.name);
    }

    public override void OnInteract()
    {
        //if (coroutineAllowed)
        //{
        //    StartCoroutine(RotateObject());
        //}

        //if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
        //{
        //    keypadButton.PressButton();
        //}

        TryGetComponent(out KeypadButton keypadButton);
        keypadButton.PressButton();


        print("Interacted with " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stop looking at " + gameObject.name);
    }

    //private IEnumerator RotateObject()
    //{
    //    coroutineAllowed = false;

    //    for(int i = 0; i < 10; i++)
    //    {
    //        transform.Rotate(-9f, 0f, 0f);
    //        yield return new WaitForSeconds(0.03f);
    //    }

    //    coroutineAllowed = true;
    //}
}
