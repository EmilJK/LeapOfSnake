using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Time.timeScale = 1f;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
}
