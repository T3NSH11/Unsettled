using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject checkpointsManager;
    public GameObject player;
    public float checkpointrange;
    public bool collected;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkpointsManager = GameObject.FindGameObjectWithTag("CheckpointsManager");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < checkpointrange && collected == false)
        {
            
            checkpointsManager.GetComponent<CheckpointsManager>().Checkpoints.Push(gameObject);
            collected = true;
            player.GetComponent<Stats>().SaveGame();
        }
    }
}
