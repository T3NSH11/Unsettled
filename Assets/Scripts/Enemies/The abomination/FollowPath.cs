using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        AbominationState.animator.SetBool("Iswalking", true);
        AbominationState.animator.SetBool("IsRunning", false);
        float node_Distance = Vector3.Distance(AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position, AbominationState.transform.position);
        AbominationState.transform.position = Vector3.MoveTowards(AbominationState.transform.position, AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position, Time.deltaTime * AbominationState.AbominationPatrolSpeed);

        var object_Rotation = Quaternion.LookRotation(AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position - AbominationState.transform.position);
        AbominationState.transform.rotation = Quaternion.Slerp(AbominationState.transform.rotation, object_Rotation, Time.deltaTime * AbominationState.rotationSpeed);

        AbominationState.AbominationPos.transform.rotation = AbominationState.transform.rotation;

        AbominationState.SearchTime = 0;

        if (node_Distance <= AbominationState.waypointDist)
        {
            AbominationState.currentPath_NodeID++;
        }

        if (AbominationState.currentPath_NodeID >= AbominationState.current_SetPath.pathNodes.Count)
        {
            AbominationState.currentPath_NodeID = 0;
        }

        if (AbominationState.fov.PlayerDetected)
        {
            AbominationState.animator.SetTrigger("player found");
            AbominationState.SwitchState(new ChasePlayer());
        }

        if (Vector3.Distance(AbominationState.AbominationPos.transform.position, AbominationState.player.transform.position) < AbominationState.AbominationAttackRange)
        {
            AbominationState.animator.SetTrigger("Attack");
            AbominationState.SwitchState(new Attack());
        }
    }
}
