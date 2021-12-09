using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : TheJesterState
{
    public override void JesterStateUpdate(TheJesterStateMachine TheJesterState)
    {
        if (TheJesterState.JesterTimer > TheJesterState.JesterSpeed)
        {
            TheJesterState.TheJester.transform.position = TheJesterState.ActiveSpawnPoints[Random.Range(0, TheJesterState.ActiveSpawnPoints.Length)].transform.position;
            TheJesterState.JesterTimer = 0;
        }

        if (Vector3.Distance(TheJesterState.TheJester.transform.position, TheJesterState.Player.transform.position) < TheJesterState.JesterAttackRange)
        {
            TheJesterState.SwitchState(new Scare());
        }
    }
}
