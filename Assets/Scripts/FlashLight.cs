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
    public int yellow_indicator_level;
    public int red_indicator_level;
    private int power = 100;
    private float original_intensity;

    void Start()
    {

        FlashLight = GetComponent<Light>();
        original_intensity = FlashLight.intensity;
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
    }
    void FixedUpdate()
    {
        if (power < red_indicator_level)
        {
            Percentage.color = Color.red;
            FlashLight.intensity = original_intensity / 2;
        }
        else
        {
            if (power < yellow_indicator_level)
            {
                Percentage.color = Color.yellow;
                FlashLight.intensity = original_intensity / 1.3f;
            }
            else
            {
                FlashLight.intensity = original_intensity;
                Percentage.color = Color.green;
            }
        }
    }
    void Update()
    {

        if (FlashLight.enabled)
        {
            if (rand.Next(0, 5000) < 2)
            {
                power -= 1;
                Debug.Log(power);
            }
        }
        //Number of clips has to be even. First half are "turn on" sounds, Second half are "turn off" sounds.
        if (Input.GetButtonDown("Flashlight"))
        {
            if (FlashLight.enabled)
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
    public void Restore_Capacity()
    {
        if (power > 50)
            power = 100;
        else
            power += 50;
    }
}