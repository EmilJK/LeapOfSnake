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
}
