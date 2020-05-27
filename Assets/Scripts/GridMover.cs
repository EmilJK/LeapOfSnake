using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GridMover : MonoBehaviour
{
    AstarPath astarPath;
    
    void Start()
    {
        astarPath = GetComponent<AstarPath>();
    }

    void Update()
    {
        
    }

    public void MoveGrid(GameObject newRoom)
    {
        astarPath.data.gridGraph.center = newRoom.transform.position;
        astarPath.Scan();
    }
}
