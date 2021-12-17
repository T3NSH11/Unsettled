using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.animator.SetBool("IsRunning", true);
        AbominationState.animator.SetBool("Iswalking", false);
        AbominationState.gameObject.transform.position = Vector3.MoveTowards(AbominationState.gameObject.transform.position, AbominationState.PlayerLostLoc, Time.deltaTime * AbominationState.AbominationChaseSpeed);
        AbominationState.SearchTime += Time.deltaTime;
  
        if (AbominationState.fov.PlayerDetected)
        {
            AbominationState.animator.SetTrigger("player found");
            AbominationState.SwitchState(new ChasePlayer());
        }

        if (AbominationState.SearchTime > 10)
        {
            AbominationState.SwitchState(new GoToPath());
        }

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.animator.SetTrigger("Attack");
            AbominationState.SwitchState(new Attack());
        }
    }
}
