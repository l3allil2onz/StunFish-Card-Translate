using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadNewsScene()
    {
        SceneManager.LoadScene("News");
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}
