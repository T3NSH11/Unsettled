using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactables
{
    public override void Action(Interact Interacables)
    {
        Debug.Log("HP");
        Interact.ItemStack.Push(this);
    }

    public override void Use(Interact Interacables)
    {
        Debug.Log("HP Use");
    }
}
