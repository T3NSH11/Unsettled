using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject HUD;
    public GameObject Controls;
    public GameObject PauseMenuOBJ;
    public Scene MainMenuScene;

    public void ControlsGame()
    {
        Controls.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TutorialGame()
    {
        Tutorial.SetActive(true);
    }

    public void ResumeGame()
    {
        HUD.SetActive(true);
        PauseMenuOBJ.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menue");
    }

    public void Back()
    {
        Controls.SetActive(false);
        Tutorial.SetActive(false);
    }
}
