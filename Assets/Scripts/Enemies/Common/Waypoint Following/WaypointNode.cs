using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : MonoBehaviour
{
    public bool Enabled = true;
    Renderer NodeRenderer;
    public GameObject Player;
    public float DistanceFromPlayer;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        NodeRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Enabled = !NodeRenderer.isVisible;
        if (Enabled)
        {
            Debug.Log("seeee");
        }

        DistanceFromPlayer = Vector3.Distance(Player.transform.position, gameObject.transform.position);
    }
}
