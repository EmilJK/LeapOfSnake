using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool rightMode;
    public static bool tutorialSeen = false;

    public GameObject pauseMenuUI, settingsMenuUI, deathMenuUI, shopMenuUI, controlsMenuUI;
    public GameObject gameUI;
    public GameObject buttonL, buttonR;
    public Button trailOne, trailTwo, trailThree, deselectTrail;

    public GameManager gameManager;
    GeneralSettings jsonScript;
    public Button leftButton, rightButton;

    private void Start()
    {
        jsonScript = FindObjectOfType<GeneralSettings>();

        rightMode = jsonScript.isRight;
        tutorialSeen = jsonScript.tutorialSeen;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (!tutorialSeen)
            {
                tutorialSeen = true;
                ControlsMenu();
            }
        }
    }

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
        else if (rightMode)
        {
            buttonR.SetActive(true);
            buttonL.SetActive(false);

            rightButton.interactable = (false);
            leftButton.interactable = (true);
        }

        if (trailOne != null)
        {
            switch (jsonScript.selectedTrail)
            {
                case 1:
                    trailOne.interactable = (false);
                    trailTwo.interactable = (true);
                    trailThree.interactable = (true);
                    break;
                case 2:
                    trailOne.interactable = (true);
                    trailTwo.interactable = (false);
                    trailThree.interactable = (true);
                    break;
                case 3:
                    trailOne.interactable = (true);
                    trailTwo.interactable = (true);
                    trailThree.interactable = (false);
                    break;
                case 0:
                    trailOne.interactable = (true);
                    trailTwo.interactable = (true);
                    trailThree.interactable = (true);
                    break;
            }

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
    public void ControlsMenu()
    {
        Time.timeScale = 0f;
        controlsMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        jsonScript.tutorialSeen = tutorialSeen;
        jsonScript.SaveSettings();
    }
    public void ControlsMainMenu()
    {
        controlsMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
    public void BackFromControls()
    {
        controlsMenuUI.SetActive(false);
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
        shopMenuUI.SetActive(false);
    }

    public void SwapToLeftMode()
    {
        if (rightMode)
        {
            rightMode = false;

            jsonScript.isRight = rightMode;
            jsonScript.SaveSettings();
            //rightButton.interactable = (false);
            //leftButton.interactable = (true);
        }
    }
    public void SwapToRightMode()
    {
        if (!rightMode)
        {
            rightMode = true;

            jsonScript.isRight = rightMode;
            jsonScript.SaveSettings();
            //rightButton.interactable = (true);
            //leftButton.interactable = (false);
        }
    }

    public void EquipTrailOne()
    {
        jsonScript.selectedTrail = 1;
        jsonScript.SaveSettings();
    }
    public void EquipTrailTwo()
    {
        jsonScript.selectedTrail = 2;
        jsonScript.SaveSettings();
    }
    public void EquipTrailThree()
    {
        jsonScript.selectedTrail = 3;
        jsonScript.SaveSettings();
    }
    public void DeselectTrail()
    {
        jsonScript.selectedTrail = 0;
        jsonScript.SaveSettings();
    }
}
