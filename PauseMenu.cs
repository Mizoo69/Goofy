using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;
    public GameObject Timer;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject YouFailed;
    public GameObject YouPassed;
    public TextMeshProUGUI keys;

    void Update()
    {
        if (YouPassed.activeSelf == false && YouFailed.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!GameIsPaused)
                {
                    PauseGame();
                    GameIsPaused = true;
                    Enemy1.SetActive(false);
                    Enemy2.SetActive(false);
                    keys.enabled=false;
                }
                else
                {
                    ResumeGame();
                    GameIsPaused = false;
                    Enemy1.SetActive(true);
                    Enemy2.SetActive(true);
                    keys.enabled = true;
                }
            }
        }
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Timer.SetActive(false);
 
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Timer.SetActive(true);

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}