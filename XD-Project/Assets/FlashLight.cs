using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class FlashLightComponent : MonoBehaviour
{
    private Light FlashLight;
    public AudioClip[] audioClips;
    private AudioSource Sound;
    public System.Random rand;
    public UnityEngine.UI.Image Percentage;
    private int power = 100;

    void Start()
    {
        FlashLight = GetComponent<Light>();
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
    }

    void Update()
    {
        if (power<90)
        {
            Percentage.color = Color.yellow;
        }
        if (FlashLight.enabled)
        {
            if(rand.Next(0,5000) < 2)
            {
                power -= 1;
                Debug.Log(power);
            }
        }
        //Number of clips has to be even. First half are "turn on" sounds, Second half are "turn off" sounds.
        if (Input.GetButtonDown("Flashlight"))
        {
            if(FlashLight.enabled)
            {
                Sound.clip = audioClips[rand.Next(audioClips.Length / 2, audioClips.Length)];
            }
            else
            {
                Sound.clip = audioClips[rand.Next(0, audioClips.Length / 2)];
            }
            Sound.Play();
            FlashLight.enabled = !FlashLight.enabled;
        }
    }
}
