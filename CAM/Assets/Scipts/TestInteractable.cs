using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interractable
{
    public override void OnFocus() //<<<------ CAN BE USED TO ACTIVATE A JUMP SCARE THE MOMENT YOU LOOK AT AN ITEM. [OPTONAL]
    {
        print("LOOKING AT " + gameObject.name);
    }

    public override void OnInteract() //<<<<------- CAN BE USED TO INTERACT WITH ITEMS.
    {
        print("INTERACTED WITH " + gameObject.name);
    }

    public override void OnLoseFocus() //<<<<<<------ CAN BE USED TO ACTIVATE SOMETHING WHEN LOOKED AWAY FROM A COMPUTER. [OPTIONAL]
    {
        print(" STOPPED LOOKING AT " + gameObject.name);
    }
}
