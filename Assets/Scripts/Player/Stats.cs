using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Range(0f, 100f)]
    public float health;
    [Range(0f, 100f)]
    public float stamina;
    [Range(0f, 100f)]
    public float battery;
    public GameObject flash;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= 10 * Time.deltaTime;
        }
        else if (stamina <= 100)
        {
            stamina += 6 * Time.deltaTime;
        }

        if (flash.GetComponent<Light>().enabled == true)
        {
            battery -= 15 * Time.deltaTime;
        }
        else
        {
            battery += 5 * Time.deltaTime;
        }
    }
}
