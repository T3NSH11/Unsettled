using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        while (AbominationState.animationwait < 3)
        {
            AbominationState.animationwait += Time.deltaTime;
        }
        AbominationState.animator.SetBool("IsRunning", true);
        AbominationState.animator.SetBool("Iswalking", false);
        AbominationState.AbominationPos.transform.position = Vector3.MoveTowards(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position, Time.deltaTime * AbominationState.AbominationChaseSpeed);
        var object_Rotation = Quaternion.LookRotation(AbominationState.player.transform.position - AbominationState.AbominationPos.transform.position);
        AbominationState.AbominationPos.transform.rotation = Quaternion.Slerp(AbominationState.AbominationPos.transform.rotation, object_Rotation, Time.deltaTime * AbominationState.rotationSpeed);
        AbominationState.SearchTime = 0;
        if (!AbominationState.PlayerDetected)
        {
            AbominationState.animationwait = 0;
            AbominationState.SwitchState(new SearchForPlayer());
        }

        if (AbominationState.SearchTime > 2)
        {
            AbominationState.animationwait = 0;
            AbominationState.SwitchState(new GoToPath());
        }

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.animationwait = 0;
            AbominationState.animator.SetTrigger("Attack");
            AbominationState.SwitchState(new Attack());
        }
    }
}
