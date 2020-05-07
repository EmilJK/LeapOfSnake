using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    //A reference to the manager object in the scene
    private LevelGenManager theGenManager;

    //A reference to the point to instantiate a new room on
    private RoomSpawner mySpawnPoint;

    void Start()
    {
        theGenManager = GameObject.FindObjectOfType<LevelGenManager>();
        mySpawnPoint = GetComponentInChildren<RoomSpawner>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the GameObject with the tag "Player" goes through the trigger assigned to generate a new room on the SpawnPoint object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player)
        {
            GameObject room = Instantiate(theGenManager.NewRoom(), mySpawnPoint.transform.position, Quaternion.identity, theGenManager.roomParent);
            theGenManager.RemoveARoom(room);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
