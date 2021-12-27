using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
    
    public GameObject Tutorial;
    public GameObject Controls;
    public GameObject MainMenu;
    public Scene GameScene;
    public Scene MainMenuScene;

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Greybox 2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Greybox 2");
    }

    public void ControlsGame()
    {
        Controls.SetActive(true);
    }

    public void TutorialGame()
    {
        Tutorial.SetActive(true);
    }

    public void MainMenuGame()
    {
        Controls.SetActive(false);
        Tutorial.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Back()
    {
        Controls.SetActive(false);
        Tutorial.SetActive(false);
    }
}
