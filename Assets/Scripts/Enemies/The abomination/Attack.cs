using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.player.GetComponent<Stats>().health -= 0.2f;
        AbominationState.SwitchState(new Stunned());
    }
}
