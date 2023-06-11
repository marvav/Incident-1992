using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class FlashLightComponent : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource Sound;
    public System.Random rand;
    public int start_flicker_at;
    public int flashlight_dies_at;
    public Light LongDistanceFlashLight;
    public Light FlashLight;
    public Light NearLight;
    public Light bodyLight;
    public Light itemLight;
    public Light AmbientLight;
    private bool isFlickering;
    public int power = 100;
    public int monsterRevealer;
    private float original_intensity;
    private float nearLight_intensity;
    private float LongDistance_intensity;

    void Start()
    {
        original_intensity = FlashLight.intensity;
        nearLight_intensity = NearLight.intensity;
        LongDistance_intensity = LongDistanceFlashLight.intensity;
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
    }
    void FixedUpdate()
    {
        if(power < flashlight_dies_at)
        {
            NearLight.intensity = 0;
            FlashLight.intensity = 0;
            LongDistanceFlashLight.intensity = 0;
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
                setIntensity();
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
        itemLight.enabled = !itemLight.enabled;
        NearLight.enabled = !NearLight.enabled;
        FlashLight.enabled = !FlashLight.enabled;
        AmbientLight.enabled = !AmbientLight.enabled;
        LongDistanceFlashLight.enabled = !LongDistanceFlashLight.enabled;
    }
    void setIntensity()
    {
        NearLight.intensity = rand.Next(0, (int)nearLight_intensity);
        FlashLight.intensity = rand.Next(0, (int)original_intensity);
        LongDistanceFlashLight.intensity = rand.Next(0, (int)LongDistance_intensity);
    }
    void Update()
    {

        if (FlashLight.enabled)
        {
            if (power >0 && rand.Next(0, 3000) < 2)
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
        NearLight.intensity = nearLight_intensity;
        FlashLight.intensity = original_intensity;
        LongDistanceFlashLight.intensity = LongDistance_intensity;
        if (power > 50)
            power = 100;
        else
            power += 50;
    }
}