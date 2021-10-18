using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : Interactables
{
    public override void Action(Interact Interacables)
    {
        Debug.Log("ST");
    }

    public override void Use(Interact Interacables)
    {
        Debug.Log("ST Use");
    }
}
