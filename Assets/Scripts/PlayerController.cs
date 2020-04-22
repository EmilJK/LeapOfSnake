using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Player Info
    [Header("Player Values")]
    public float playerGravity = 0.2f;
    public float velocityDamp = 2f;
    public float tiltSpeed = 1f;

    float dirX;

    #endregion

    public Rigidbody2D rb;
    void awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = playerGravity;
    }

    void Update()
    {
        //dirX = Input.acceleration.x * tiltSpeed;
        //transform.position = new Vector2(transform.position.x, transform.position.y);

        transform.Translate(Input.acceleration.x * tiltSpeed, 0,0);

        if (Input.GetMouseButtonDown(0)) //When screen pressed set the velocity of snake 0
        {
            rb.velocity = Vector2.zero;
        }
        rb.AddForce(-rb.velocity * velocityDamp); //Damps the velocity of the player
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
}
