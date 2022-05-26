using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Start new game button
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
