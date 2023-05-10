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
    public int start_flicker_at;
    public int flashlight_dies_at;
    public Light groundLight;
    public Light bodyLight;
    public Light AmbientLight;
    private bool isFlickering;
    public int power = 100;
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
        if(power < flashlight_dies_at)
        {
            setIntensity(0);
            return;
        }
        if (power < start_flicker_at && rand.Next(0, 2000) == 1)
        {
            Debug.Log("Started flickering");
            isFlickering = true;
        }
        if(isFlickering)
        {
            int random = rand.Next(0, 5000);
            if (random > 4500)
            {
                setIntensity(rand.Next(0, (int) original_intensity));
            }
            if(random < 10)
            {
                Debug.Log("Stopped flickering");
                isFlickering = false;
            }
        }
    }
    void switchLight()
    {
        bodyLight.enabled = !bodyLight.enabled;
        groundLight.enabled = !groundLight.enabled;
        FlashLight.enabled = !FlashLight.enabled;
        AmbientLight.enabled = !AmbientLight.enabled;
    }
    void setIntensity(int value)
    {
        bodyLight.intensity = value;
        groundLight.intensity = value;
        FlashLight.intensity = value;
    }
    void Update()
    {

        if (FlashLight.enabled)
        {
            if (power >0 && rand.Next(0, 5000) < 2)
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
            isFlickering = false;
            switchLight();
        }
    }
    public void Restore_Capacity()
    {
        setIntensity((int) original_intensity);
        if (power > 50)
            power = 100;
        else
            power += 50;
    }
}