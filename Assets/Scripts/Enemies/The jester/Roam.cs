using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : TheJesterState
{
    public override void JesterStateUpdate(TheJesterStateMachine TheJesterState)
    {
        TheJesterState.JesterLoc = Random.Range(0, TheJesterState.JesterSpawnPoints.Length);
        if (TheJesterState.JesterTimer > TheJesterState.JesterSpeed)
        {
            TheJesterState.TheJester.transform.position = TheJesterState.JesterSpawnPoints[TheJesterState.JesterLoc].transform.position;
            TheJesterState.JesterTimer = 0;
        }

        if(Vector3.Distance(TheJesterState.TheJester.transform.position, TheJesterState.Player.transform.position) < TheJesterState.JesterRange)
        {
            TheJesterState.SwitchState(new Follow());
        }

        if (Vector3.Distance(TheJesterState.TheJester.transform.position, TheJesterState.Player.transform.position) < TheJesterState.JesterAttackRange)
        {
            TheJesterState.SwitchState(new Scare());
        }
    }
}
