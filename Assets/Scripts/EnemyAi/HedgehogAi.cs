using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogAi : MonoBehaviour
{
    public float speed = 1;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("sfx__Hedgehog_attack02");
        }
    }
}
