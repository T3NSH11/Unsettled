using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactables
{
    public override void Action(Interact Interacables)
    {
        Debug.Log("HP");
    }

    public override void Use(Inventory Interacables)
    {
        Debug.Log("HP Use");
    }
}
