using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public GameObject countdown1, countdown2, countdown3, jump;
    public PlayerController player;
    public Button pauseButtonL, pauseButtonR;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        Countdown();
    }

    public void Countdown()
    {
        player.enabled = (false);
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        StartCoroutine(Counting());
    }

    public IEnumerator Counting()
    {
        pauseButtonL.enabled = (false);
        pauseButtonR.enabled = (false);
        Number3();
        yield return new WaitForSeconds(1f);
        Number2();
        yield return new WaitForSeconds(1f);
        Number1();
        yield return new WaitForSeconds(1f);
        StartGame();
        yield return new WaitForSeconds(1f);
        jump.SetActive(false);
        pauseButtonL.enabled = (true);
        pauseButtonR.enabled = (true);
        //Remember the JUMP!!
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
        jump.SetActive(true);
        player.enabled = (true);
        player.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
