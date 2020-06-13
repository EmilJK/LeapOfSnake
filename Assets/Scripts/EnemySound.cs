using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public Collider2D myRoom;
    public GameObject player;

    float timerSet = 3f;
    public float timer;
    void Start()
    {
        myRoom = transform.parent.GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        timer = timerSet;
    }

    // Update is called once per frame
    void Update()
    {

        CheckForPlayer();

    }

    void CheckForPlayer()
    {
        if (!myRoom.bounds.Contains(player.transform.position))
        {          
            if (timer <= 0)
            {
                Invoke("DeleteMe", 0.5f);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            timer = timerSet;
        }
    }
    void DeleteMe()
    {
        Destroy(gameObject);
    }
}
