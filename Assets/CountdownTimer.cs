using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public GameObject countdown1, countdown2, countdown3;

    void Start()
    {
        //Time.timeScale = 1f;
        Countdown();
    }

    public void Countdown()
    {
        StartCoroutine(Counting());
    }

    public IEnumerator Counting()
    {
        Number3();
        yield return new WaitForSeconds(1f);
        Number2();
        yield return new WaitForSeconds(1f);
        Number1();
        yield return new WaitForSeconds(1f);
        StartGame();

        yield return null;
    }

    void Number3()
    {
        countdown3.SetActive(true);
    }
    void Number2()
    {
        countdown2.SetActive(true);
        countdown3.SetActive(false);
    }
    void Number1()
    {
        countdown1.SetActive(true);
        countdown2.SetActive(false);
    }
    void StartGame()
    {
        countdown1.SetActive(false);
        Time.timeScale = 1f;
    }
}
