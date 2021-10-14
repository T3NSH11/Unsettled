using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage : Interactables
{
    public override void Action(Interact Interacables)
    {
        Debug.Log("JP");
    }

    public override void Use(Inventory Interacables)
    {
        Debug.Log("JP Use");
    }
}
