using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAi : MonoBehaviour
{
    public float speed = 2;
    bool movingRight = true;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else if (movingRight == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("sfx_Bat_attack");
        }
    }
}
