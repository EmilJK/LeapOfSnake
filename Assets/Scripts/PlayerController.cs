using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    #region Player Info
    [Header("Player Values")]
    public int playerHP = 1;
    public float playerGravity = 0.2f;
    public float velocityDamp = 2f;
    public float tiltSpeed = 1f;
    public float jumpHeight = 1;
    public float swipePower = 15f;
    public float maxXVelocity = 1;
    public float cdSet = 1;
    public float jumpCD, swipeCD;    
    //float dirX;

    bool canSwipe, canJump;
    #endregion

    public Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale = playerGravity;

        playerHP = 1;

        jumpCD = cdSet; swipeCD = cdSet;
    }

    void Update()
    {
        CooldownTimer();
        #region TiltControls
        /*dirX = Input.acceleration.x * tiltSpeed;
        Mathf.Clamp(dirX, 0, 1);
        transform.position = new Vector2(transform.position.x, transform.position.y);*/
        #endregion

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) //When screen pressed set the velocity of snake 0
        {
            JumpFunction();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwipeLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwipeRight();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.resetScene();
        }
#endif
        if(playerHP <=0)
            gameManager.resetScene();
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y); //TiltControls
        transform.Translate(Input.acceleration.x * tiltSpeed * Time.deltaTime, 0, 0);
        rb.AddForce(-rb.velocity * velocityDamp); //Damps the velocity of the player
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerHP--;
        }
    }

    private void CooldownTimer()
    {
        if (jumpCD <= 0)
            canJump = true;
        else
            jumpCD -= Time.deltaTime;

        if (swipeCD <= 0)
            canSwipe = true;
        else
            swipeCD -= Time.deltaTime;
    }

    public void JumpFunction()
    {
        if (canJump)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpCD = cdSet;
            canJump = false;
        }
        
    }

    public void SwipeRight()
    {
        if (canSwipe)
        {
            rb.velocity += new Vector2(swipePower, 0);
            swipeCD = cdSet;
            canSwipe = false;
        }
    }
    public void SwipeLeft()
    {
        if (canSwipe)
        {
            rb.velocity += new Vector2(-swipePower, 0);
            swipeCD = cdSet;
            canSwipe = false;
        }
    }
}
