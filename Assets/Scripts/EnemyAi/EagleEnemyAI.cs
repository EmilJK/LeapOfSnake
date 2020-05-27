using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleEnemyAI : MonoBehaviour
{
    Transform pointL, pointR;
    Collider2D greenBox;
    Vector2 point;
    Transform eaglePoint;
    AIPath aPath;
    AIDestinationSetter desSetter;

    bool toRightPoint = true;

    public enum EagleState {towardsPlayer, awayPlayer};
    public EagleState myState = EagleState.towardsPlayer;

    void Start()
    {
        pointL = GameObject.FindGameObjectWithTag("LeftPoint").transform;
        pointR = GameObject.FindGameObjectWithTag("RightPoint").transform;
        greenBox = GameObject.FindGameObjectWithTag("Green_Box").GetComponent<Collider2D>();

        eaglePoint = GameObject.FindGameObjectWithTag("EaglePoint").transform;

        aPath = GetComponent<AIPath>();
        desSetter = GetComponent<AIDestinationSetter>();

        //play Eagle arrival AMERICA sound! 
    }

    void Update()
    {
        switch (myState)
        {
            case EagleState.towardsPlayer:
                StartCoroutine(Towards());
                break;
            case EagleState.awayPlayer:
                StartCoroutine(Away());
                break;

        }
    }

    IEnumerator Towards()
    {
        //play Eagle Attack! sound
        point.x = Random.Range(greenBox.bounds.min.x, greenBox.bounds.max.x);
        point.y = Random.Range(greenBox.bounds.min.y, greenBox.bounds.max.y);
        eaglePoint.position = new Vector2(point.x, point.y);
        desSetter.target = eaglePoint;

        while (!aPath.reachedEndOfPath)
        {
            yield return new WaitForSeconds(0.1f);
        }
        myState = EagleState.awayPlayer;
        yield return null;
    }
    IEnumerator Away()
    {
        if (toRightPoint)
        {
            desSetter.target = pointR;            
        }
        else
        {
            desSetter.target = pointL;
        }
        toRightPoint = !toRightPoint;

        while (!aPath.reachedEndOfPath)
        {
            yield return new WaitForSeconds(0.1f);
        }
        myState = EagleState.towardsPlayer;
        yield return null;
    }
}
