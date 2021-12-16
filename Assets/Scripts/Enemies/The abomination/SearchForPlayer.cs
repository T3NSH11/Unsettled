using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.gameObject.transform.position = Vector3.MoveTowards(AbominationState.gameObject.transform.position, AbominationState.PlayerLostLoc, Time.deltaTime * AbominationState.AbominationChaseSpeed);
        AbominationState.SearchTime += Time.deltaTime;
  
        if (AbominationState.fov.PlayerDetected)
        {
            AbominationState.SwitchState(new ChasePlayer());
        }

        if (AbominationState.SearchTime > 10)
        {
            AbominationState.SwitchState(new GoToPath());
        }

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.SwitchState(new Attack());
        }
    }
}
