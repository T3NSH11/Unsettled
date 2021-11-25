using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : TheJesterState
{
    public override void JesterStateUpdate(TheJesterStateMachine TheJesterState)
    {
        TheJesterState.ActiveSpawnPoints = Physics.OverlapSphere(TheJesterState.Player.transform.position, 15, TheJesterState.spawnlayer);
        if (TheJesterState.JesterTimer > TheJesterState.JesterSpeed)
        {
            TheJesterState.TheJester.transform.position = TheJesterState.ActiveSpawnPoints[Random.Range(0, TheJesterState.ActiveSpawnPoints.Length)].transform.position;
        }

        if (Vector3.Distance(TheJesterState.TheJester.transform.position, TheJesterState.Player.transform.position) < TheJesterState.JesterAttackRange)
        {
            TheJesterState.SwitchState(new Scare());
        }
    }
}
