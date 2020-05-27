using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public static bool rightMode = false;

    public GameObject pauseMenuUI, settingsMenuUI;
    public GameObject gameUI;
    public GameObject buttonL, buttonR;

    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
#endif

        if (!rightMode)
        {
            buttonL.SetActive(true);
            buttonR.SetActive(false);
        }
        else
        {
            buttonR.SetActive(true);
            buttonL.SetActive(false);
        }

    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void MainMenu()
    {
        gameManager.MainMenuScene();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        gameManager.ResetScene();
    }
    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }
    public void SettingsMainMenu()
    {
        settingsMenuUI.SetActive(true);
    }
    public void BackToPause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
    public void Back()
    {
        settingsMenuUI.SetActive(false);
    }
    public void SwapLRMode()
    {
        if (rightMode)
        {
            rightMode = false;
        }
        else
        {
            rightMode = true;
        }
    }
}
