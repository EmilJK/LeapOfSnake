using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerJump, playerAttack, playerDie,
        eagleAttack, enemyDie, hitRock;
    static AudioSource audioSrc;


    void Start()
    {
        playerJump = Resources.Load<AudioClip>("sfx_Snake_jump");
        playerAttack = Resources.Load<AudioClip>("sfx_Snake_attack");
        playerDie = Resources.Load<AudioClip>("sfx_Snake_dying");

        eagleAttack = Resources.Load<AudioClip>("sfx_Eagle_attack");
        enemyDie = Resources.Load<AudioClip>("sfx_Enemy_dying");
        hitRock = Resources.Load<AudioClip>("sfx_Rock_crash");

        audioSrc = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sfx_Snake_jump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "sfx_Snake_attack":
                audioSrc.PlayOneShot(playerAttack);
                break;
            case "sfx_Snake_dying":
                audioSrc.PlayOneShot(playerDie);
                break;
            case "sfx_Eagle_attack":
                audioSrc.PlayOneShot(eagleAttack);
                break;
            case "sfx_Enemy_dying":
                audioSrc.PlayOneShot(enemyDie);
                break;
            case "sfx_Rock_crash":
                audioSrc.PlayOneShot(hitRock);
                break;

        }
    }
}
