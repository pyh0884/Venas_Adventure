using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    public void Play(int number)
    {
        if (DeadMenu != null)
        {
            DeadMenu.SetActive(false);
        }

        if (PauseMenu != null)
            {
            PauseMenu.SetActive(false);
            }

            Time.timeScale = 1;
        SceneManager.LoadScene(number);
    }

    public void RePlay()
    {
        if (DeadMenu != null)
        {
            DeadMenu.SetActive(false);
        }
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }


        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ContinuePlay()
        {if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
        Time.timeScale = 1;
        }
}
