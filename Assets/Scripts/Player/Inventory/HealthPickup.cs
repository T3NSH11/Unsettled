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
        Interacable.player.GetComponent<Stats>().health += 0.25f;
    }
}
