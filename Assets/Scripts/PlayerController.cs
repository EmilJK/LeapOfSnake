using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Player Info
    [Header("Player Values")]
    public float playerGravity = 0.2f;
    public float maxVelocity = 2f;

    #endregion

    public Rigidbody2D rb;
    void awake()
    {
        rb.gravityScale = playerGravity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //When screen pressed set the velocity of snake 0
        {
            rb.velocity = Vector2.zero;
        }
        rb.AddForce(-rb.velocity * maxVelocity); //Damps the velocity of the player
    }
}
