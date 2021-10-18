using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactables
{
    public override void Action(Interact Interactable)
    {
        Debug.Log("HP");
        Interactable.ItemStack.Push(this);
    }

    public override void Use(Interact Interacable)
    {
        Debug.Log("HP Use");
    }
}
