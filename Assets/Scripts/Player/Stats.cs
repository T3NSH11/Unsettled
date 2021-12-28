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
    public GameObject Abomination;
    public GameObject Jester;
    public GameObject CheckpointManager;
    public GameObject[] Checkpoints;
    public Vector3 AbominationPosition;
    public Vector3 JesterPosition;
    void Start()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
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

    public void SaveGame()
    {
        AbominationPosition = Abomination.transform.position;
        JesterPosition = Jester.transform.position;

        for (int i = 0; i < Checkpoints.Length; i++)
        {
            PlayerPrefs.SetInt("Checkpoint" + i + "collected?", (Checkpoints[i].GetComponent<Checkpoints>().collected ? 1 : 0));
        }

        PlayerPrefs.SetFloat("AbominationPosX",AbominationPosition.x);
        PlayerPrefs.SetFloat("AbominationPosY", AbominationPosition.y);
        PlayerPrefs.SetFloat("AbominationPosZ", AbominationPosition.z);

        PlayerPrefs.SetFloat("JesterPosX", JesterPosition.x);
        PlayerPrefs.SetFloat("JesterPosY", JesterPosition.y);
        PlayerPrefs.SetFloat("JesterPosZ", JesterPosition.z);

        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.y);

        PlayerPrefs.SetInt("Checkpointcount", CheckpointManager.GetComponent<CheckpointsManager>().Collcheckpoints);
    }
}
