using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Tutorial;
    public GameObject Controls;
    public GameObject MainMenu;
    public Scene GameScene;
    public Scene MainMenuScene;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Greybox 2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {

    }

    public void ControlsGame()
    {
        MainMenu.SetActive(false);
        Controls.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void TutorialGame()
    {
        MainMenu.SetActive(false);
        Tutorial.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void MainMenuGame()
    {
        Controls.SetActive(false);
        Tutorial.SetActive(false);
        PauseMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
