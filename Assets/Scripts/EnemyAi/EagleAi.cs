using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleAi : MonoBehaviour
{
    public AIPath aiPath;

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.44321f, 0.44321f, 0.44321f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-0.44321f, 0.44321f, 0.44321f);
        }
    }
}
