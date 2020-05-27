using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            //player.TakeDmg();
            Destroy(gameObject);
        }
    }
}
