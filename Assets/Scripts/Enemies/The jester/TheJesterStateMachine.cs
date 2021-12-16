using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheJesterStateMachine : MonoBehaviour
{
    public TheJesterState CurrentState;
    public GameObject[] JesterSpawnPoints;
    public Collider[] ActiveSpawnPoints;
    public GameObject TheJester;
    public GameObject Player;
    public GameObject JumpScare;
    public LayerMask spawnlayer;
    public int JesterLoc;
    public float JesterSpeed;
    public float JesterTimer;
    public float JesterRange;
    public float JesterAttackRange;
    void Start()
    {
        JesterSpawnPoints = GameObject.FindGameObjectsWithTag("JesterSpawnPoint");
        CurrentState = new Roam();
    }

    void Update()
    {
        CurrentState.JesterStateUpdate(this);
        ActiveSpawnPoints = Physics.OverlapSphere(Player.transform.position, 15, spawnlayer);
        JesterLoc = Random.Range(0, JesterSpawnPoints.Length);
        Debug.Log(CurrentState);
        JesterTimer += Time.deltaTime;
    }

    public void SwitchState(TheJesterState JesterState)
    {
        CurrentState = JesterState;
    }
}
