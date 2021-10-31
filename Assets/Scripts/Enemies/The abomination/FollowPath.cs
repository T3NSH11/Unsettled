using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : AbominationState
{
    public override void AbominationStateUpdate(TheAbomination AbominationState)
    {
        float node_Distance = Vector3.Distance(AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position, AbominationState.transform.position);
        AbominationState.transform.position = Vector3.MoveTowards(AbominationState.transform.position, AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position, Time.deltaTime * AbominationState.AbominationPatrolSpeed);

        var object_Rotation = Quaternion.LookRotation(AbominationState.current_SetPath.pathNodes[AbominationState.currentPath_NodeID].position - AbominationState.transform.position);
        AbominationState.transform.rotation = Quaternion.Slerp(AbominationState.transform.rotation, object_Rotation, Time.deltaTime * AbominationState.rotationSpeed);

        AbominationState.SearchTime = 0;

        if (node_Distance <= AbominationState.waypointDist)
        {
            AbominationState.currentPath_NodeID++;
        }

        if (AbominationState.currentPath_NodeID >= AbominationState.current_SetPath.pathNodes.Count)
        {
            AbominationState.currentPath_NodeID = 0;
        }

        if (AbominationState.PlayerDetected)
        {
            AbominationState.SwitchState(new ChasePlayer());
        }
    }
}
