using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public void OpenScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        /*if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            cam.isMoving = false;
        }
        else
        {
            Time.timeScale = 1;
        }
        */
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
