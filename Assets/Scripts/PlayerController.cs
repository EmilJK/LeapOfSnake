﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public PauseMenu menuManager;
    LevelGenManager levelGenManager;
    GeneralSettings jsonScript;

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

    public GameObject[] trailType;
    //float dirX;

    public string dir;

    Animator snakeAnim;

    bool canSwipe, canJump;
    bool canHurt = true;
    bool inSwipe = false;
    bool jumping = false;
    #endregion

    public GameObject bloodParticles;
    public GridMover gridMover;
    GameObject currentRoom;
    public Image hpBar;
    public Sprite hpFull, hpTwo, hpOne, hpZero;
    public Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        snakeAnim = GetComponent<Animator>();

        levelGenManager = FindObjectOfType<LevelGenManager>();
        jsonScript = FindObjectOfType<GeneralSettings>();


        playerHP = 3;
        dir = "Down";

        jumpCD = cdSet; swipeCD = cdSet;
    }

    private void Start()
    {       
        if(trailType[jsonScript.selectedTrail] != null)
        {
            Invoke("MakeTrail", 2f);
        }
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
            gameManager.ResetScene();
        }
#endif
        HealthFunction();
        PlayAnim();

    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(rb.velocity.x + dirX, rb.velocity.y); //TiltControls
        transform.Translate(Input.acceleration.x * tiltSpeed * Time.deltaTime, 0, 0);
        rb.AddForce(-rb.velocity * velocityDamp); //Damps the velocity of the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(inSwipe && collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<MouseAi>() && playerHP <3)
            {
                collision.gameObject.GetComponent<MouseAi>().EatMe();
            }
            Destroy(collision.gameObject);
            SoundManager.PlaySound("sfx_Enemy_dying");
            GameObject particles = Instantiate(bloodParticles, collision.gameObject.transform.position, Quaternion.Euler(-90f,0f,0f));
        }
        else if (collision.gameObject.tag == "Enemy" && canHurt || collision.gameObject.tag == "Obstacle" && canHurt)
        {
            TakeDmg();
            canHurt = false;
            Invoke("CanHurtAgain", 2f);
        }


        if(collision.gameObject.tag == "Room")
        {
            currentRoom = collision.gameObject;
            gridMover.MoveGrid(currentRoom);
        }
    }
    void CanHurtAgain()
    {
        canHurt = true;
    }
    
    void MakeTrail()
    {
        GameObject trail = Instantiate(trailType[jsonScript.selectedTrail], transform);
    }

    public void TakeDmg()
    {
        playerHP--;
        switch (dir)
        {
            case "Down":
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                break;
            case "Up":
                rb.AddForce(new Vector2(0, -jumpHeight), ForceMode2D.Impulse);
                break;
            case "Left":
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(jumpHeight / 2, jumpHeight / 2), ForceMode2D.Impulse);
                break;
            case "Right":
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(-jumpHeight / 2, jumpHeight / 2), ForceMode2D.Impulse);
                break;

        }

    }

    void PlayAnim()
    {
        snakeAnim.SetBool("DoHurt", !canHurt);
        snakeAnim.SetBool("Jumping", jumping);
        snakeAnim.SetBool("Swiping", inSwipe);
    }

    private void SetDirDown()
    {
        dir = "Down";
        jumping = false;
    }

    private void CooldownTimer()
    {
        if (jumpCD <= 0)
        {
            canJump = true;
        }
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
            SoundManager.PlaySound("sfx_Snake_jump");
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpCD = cdSet;
            canJump = false;

            jumping = true;
            dir = "Up";
            Invoke("SetDirDown", 1f);
        }

    }

    public void SwipeRight()
    {
        if (canSwipe)
        {
            SoundManager.PlaySound("sfx_Snake_attack");
            rb.velocity += new Vector2(swipePower, 0);
            swipeCD = cdSet;
            canSwipe = false;

            dir = "Right";
            inSwipe = true;

            StartCoroutine(SwipeRotation(true));
        }
    }
    public void SwipeLeft()
    {
        if (canSwipe)
        {
            SoundManager.PlaySound("sfx_Snake_attack");
            rb.velocity += new Vector2(-swipePower, 0);
            swipeCD = cdSet;
            canSwipe = false;

            dir = "Left";
            inSwipe = true;

            StartCoroutine(SwipeRotation(false));

        }
    }

    public IEnumerator SwipeRotation(bool isRight)
    {
        if (isRight)
        {
            while (rb.velocity.x >= 10)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                yield return new WaitForSeconds(0.01f);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //dir = "Down";
            yield return null;
        }
        else
        {
            while (rb.velocity.x <= -10)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                yield return new WaitForSeconds(0.01f);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //dir = "Down";
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        dir = "Down";
        inSwipe = false;
        yield return null;
    }

    public void HealthFunction()
    {

        if (playerHP == 3)
        {
            hpBar.sprite = hpFull;
        }
        else if (playerHP == 2)
        {
            hpBar.sprite = hpTwo;
        }
        else if (playerHP == 1)
        {
            hpBar.sprite = hpOne;
        }
        else if (playerHP <= 0)
        {
            SoundManager.PlaySound("sfx_Snake_dying");
            hpBar.sprite = hpZero;

            this.gameObject.SetActive(false);
            menuManager.DeathScreen();
            SaveNewHighScore();
            //gameManager.ResetScene();
        }
    }


    public void SaveNewHighScore()
    {
        if(levelGenManager.roomsVisited >= jsonScript.highScore)
        {
            jsonScript.highScore = levelGenManager.roomsVisited;
            jsonScript.SaveSettings();
        }
    }
}
