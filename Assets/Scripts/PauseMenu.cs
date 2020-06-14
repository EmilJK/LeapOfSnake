using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public static bool rightMode = false;

    public GameObject pauseMenuUI, settingsMenuUI, deathMenuUI, shopMenuUI;
    public GameObject gameUI;
    public GameObject buttonL, buttonR;

    public GameManager gameManager;
    public Button leftButton, rightButton;


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

            rightButton.interactable = (true);
            leftButton.interactable = (false);
        }
        else
        {
            buttonR.SetActive(true);
            buttonL.SetActive(false);

            rightButton.interactable = (false);
            leftButton.interactable = (true);
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
    public void DeathScreen()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
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
    public void ShopMenu()
    {
        shopMenuUI.SetActive(true);
    }
    public void BackToPause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
    public void Back()
    {
        settingsMenuUI.SetActive(false);
        shopMenuUI.SetActive(false);
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
    public void SwapToLeftMode()
    {
        if (rightMode)
        {
            rightMode = false;

            //rightButton.interactable = (false);
            //leftButton.interactable = (true);
        }
    }
    public void SwapToRightMode()
    {
        if (!rightMode)
        {
            rightMode = true;

            //rightButton.interactable = (true);
            //leftButton.interactable = (false);
        }
    }
}
