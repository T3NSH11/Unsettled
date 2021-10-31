using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.gameObject.transform.position = Vector3.MoveTowards(AbominationState.gameObject.transform.position, AbominationState.player.transform.position, Time.deltaTime * AbominationState.AbominationChaseSpeed);
        AbominationState.SearchTime = 0;
        if (!AbominationState.PlayerDetected)
        {
            AbominationState.SwitchState(new SearchForPlayer());
        }

        if (AbominationState.SearchTime > 10)
        {
            AbominationState.SwitchState(new GoToPath());
        }

        if (Vector3.Distance(AbominationState.gameObject.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.SwitchState(new Attack());
        }
    }
}
