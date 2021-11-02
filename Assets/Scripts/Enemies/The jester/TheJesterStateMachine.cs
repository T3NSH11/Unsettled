using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheJesterStateMachine : MonoBehaviour
{
    public GameObject[] JesterSpawnPoints;
    void Start()
    {
        JesterSpawnPoints = GameObject.FindGameObjectsWithTag("JesterSpawnPoint");
    }

    void Update()
    {
        
    }
}
