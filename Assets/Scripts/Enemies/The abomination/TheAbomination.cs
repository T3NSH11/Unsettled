using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAbomination : MonoBehaviour
{
    public FOV fov;
    public bool PlayerDetected;
    public float SearchTime;
    public Vector3 PlayerLostLoc;
    public float DistanceToLost;
    public float AbominationChaseSpeed;
    public float AbominationPatrolSpeed;
    public GameObject player;
    public float AbominationAttackRange;
    public AbominationState currentstate;
    public GameObject DeathUI;
    public float waypointDist;
    public float rotationSpeed;
    public string path_Name;
    public Vector3 prevNode_Pos;
    public GameObject[] patrolPaths;
    public GameObject[] PathNodes;
    public GameObject NearestNode;
    public GameObject AbominationPos;
    public int currentPath_NodeID = 0;
    public FollowWaypoints current_SetPath;
    public Animator animator;

    void Start()
    {
        fov = gameObject.GetComponentInChildren<FOV>();
        currentstate = new FollowPath();
        currentstate.AbominationStateUpdate(this);
    }

    void Update()
    {
        PlayerDetected = fov.PlayerDetected;

        if (fov.PlayerDetected)
        {
            PlayerLostLoc = fov.playerObj.transform.position;
            SearchTime = 0;
        }

        DistanceToLost = Vector3.Distance(gameObject.transform.position, PlayerLostLoc);
        currentstate.AbominationStateUpdate(this);
        Debug.Log(currentstate);
    }
    
    public void SwitchState(AbominationState abominationState)
    {
        currentstate = abominationState;
    }
}
