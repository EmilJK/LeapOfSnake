using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerJump, playerAttack, playerDie,
        eagleAttack, batAttack, hedgehogAttack, enemyDie, hitRock,
        buttonPause, buttonPress, shopChange, shopBuy, plantAttack;
    static AudioSource audioSrc;


    void Start()
    {
        playerJump = Resources.Load<AudioClip>("sfx_Snake_jump");
        playerAttack = Resources.Load<AudioClip>("sfx_Snake_attack");
        playerDie = Resources.Load<AudioClip>("sfx_Snake_dying");

        eagleAttack = Resources.Load<AudioClip>("sfx_Eagle_attack");
        batAttack = Resources.Load<AudioClip>("sfx_Bat_attack");
        hedgehogAttack = Resources.Load<AudioClip>("sfx__Hedgehog_attack02");
        enemyDie = Resources.Load<AudioClip>("sfx_Enemy_dying");
        hitRock = Resources.Load<AudioClip>("sfx_Rock_crash");
        plantAttack = Resources.Load<AudioClip>("sfx__Plant_attack01");

        buttonPause = Resources.Load<AudioClip>("sfx_Button_pause");
        buttonPress = Resources.Load<AudioClip>("sfx_Button_press");

        shopChange = Resources.Load<AudioClip>("sfx__Shop_changeOutfit01");
        shopBuy = Resources.Load<AudioClip>("sfx__Shop_buy01");

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
            case "sfx_Bat_attack":
                audioSrc.PlayOneShot(batAttack);
                break;
            case "sfx__Hedgehog_attack02":
                audioSrc.PlayOneShot(hedgehogAttack);
                break;
            case "sfx_Enemy_dying":
                audioSrc.PlayOneShot(enemyDie);
                break;
            case "sfx_Rock_crash":
                audioSrc.PlayOneShot(hitRock);
                break;
            case "sfx__Plant_attack01":
                audioSrc.PlayOneShot(plantAttack);
                break;
            case "sfx_Button_pause":
                audioSrc.PlayOneShot(buttonPause);
                break;
            case "sfx_Button_press":
                audioSrc.PlayOneShot(buttonPress);
                break;
            case "sfx__Shop_changeOutfit01":
                audioSrc.PlayOneShot(shopChange);
                break;
            case "sfx__Shop_buy01":
                audioSrc.PlayOneShot(shopBuy);
                break;

        }
    }
}
