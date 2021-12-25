using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointsManager : MonoBehaviour
{
    public GameObject player;
    public GameObject WinUI;
    public Stack<GameObject> Checkpoints;
    public GameObject LastCheckpoint;
    public GameObject ChckCount;    
    public int Collcheckpoints;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Checkpoints = new Stack<GameObject>();
        ChckCount = GameObject.FindGameObjectWithTag("ChckCount");
    }

    void Update()
    {
        Collcheckpoints = Checkpoints.Count;
        if (Checkpoints.Count != 0)  
        {
            LastCheckpoint = Checkpoints.Peek();
        }

        if (Collcheckpoints >= 6)
        {
            WinUI.SetActive(true);
        }
        ChckCount.GetComponent<TMPro.TextMeshProUGUI>().text = Collcheckpoints.ToString();
    }
}
