using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : AbominationState
{
    float stunntimer;
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        stunntimer += Time.deltaTime;
        if (stunntimer > 5)
        {
            stunntimer = 0;
            AbominationState.animator.SetTrigger("StunnedOff");
            AbominationState.SwitchState(new GoToPath());
        }
    }
}
