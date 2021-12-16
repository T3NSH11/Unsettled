using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickup : Interactables
{
    public override void Action(Interact Interactable)
    {
        Debug.Log("ST");
        Interactable.ItemStack.Push(this);
    }

    public override void Use(Interact Interacable)
    {
        Interacable.player.GetComponent<Stats>().stamina += 1;
    }
}
