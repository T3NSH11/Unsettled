using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.DeathUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
