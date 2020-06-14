using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliders : MonoBehaviour
{
    public bool isMusicSlider;
    private Slider mySlider;
    public AudioMixer audioMixer;


    void Start()
    {
        float volume;
        mySlider = GetComponent<Slider>();

        if (isMusicSlider)
        {
            audioMixer.GetFloat("Music", out volume);
            //Debug.Log(volume);
            mySlider.value = volume;

        }
        else
        {
            audioMixer.GetFloat("SFX", out volume);
            //Debug.Log(volume);
            mySlider.value = volume;
        }
    }
}
