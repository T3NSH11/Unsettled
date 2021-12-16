using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [Range(0f, 1f)]
    public float health;
    [Range(0f, 1f)]
    public float stamina;
    [Range(0f, 1f)]
    public float battery;
    public GameObject flash;
    public Image healthbar;
    public Image staminabar;
    public GameObject deathUI;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= 0.10f * Time.deltaTime;
        }
        else if (stamina <= 1)
        {
            stamina += 0.06f * Time.deltaTime;
        }

        if (flash.GetComponent<Light>().enabled == true)
        {
            battery -= 0.15f * Time.deltaTime;
        }
        else
        {
            battery += 0.05f * Time.deltaTime;
        }

        if (health > 1)
        {
            health = 1;
        }

        if (stamina > 1)
        {
            stamina = 1;
        }
        healthbar.fillAmount = health;
        staminabar.fillAmount = stamina;
    }
}
