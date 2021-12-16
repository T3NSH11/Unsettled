using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPath : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.AbominationPos.transform.position = Vector3.MoveTowards(AbominationState.AbominationPos.transform.position, AbominationState.transform.position, Time.deltaTime * AbominationState.AbominationChaseSpeed);
        var object_Rotation = Quaternion.LookRotation(AbominationState.transform.position - AbominationState.AbominationPos.transform.position);
        AbominationState.AbominationPos.transform.rotation = Quaternion.Slerp(AbominationState.AbominationPos.transform.rotation, object_Rotation, Time.deltaTime * AbominationState.rotationSpeed);

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.SwitchState(new Attack());
        }

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.transform.position) < 1)
        {
            AbominationState.SwitchState(new FollowPath());
        }
    }
}
