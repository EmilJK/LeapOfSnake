using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAi : MonoBehaviour
{
    public float speed = 2;
    public PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void EatMe()
    {
        player.playerHP++;
    }
}
