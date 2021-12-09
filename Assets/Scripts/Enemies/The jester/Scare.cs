using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scare : TheJesterState
{
    public override void JesterStateUpdate(TheJesterStateMachine TheJesterState)
    {
        TheJesterState.JumpScare.SetActive(true);
        WaitForSeconds scaretime = new WaitForSeconds (1);
        TheJesterState.JumpScare.SetActive(false);
        TheJesterState.TheJester.transform.position = TheJesterState.JesterSpawnPoints[TheJesterState.JesterLoc].transform.position;
        TheJesterState.SwitchState(new Roam());
    }
}
