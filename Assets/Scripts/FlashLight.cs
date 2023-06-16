using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class FlashLightComponent : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource buzzing;
    private AudioSource Sound;
    public System.Random rand;
    public int start_flicker_at;
    public int flashlight_dies_at;
    public Light LongDistanceFlashLight;
    public Light FlashLight;
    public Light NearLight;
    public Light bodyLight;
    public Light AmbientLight;
    private bool isFlickering;
    public int power = 100;
    public int dischargeSpeed;
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
    void switchLight()
    {
        bodyLight.enabled = !NearLight.enabled;
        NearLight.enabled = !NearLight.enabled;
        FlashLight.enabled = !FlashLight.enabled;
        //AmbientLight.enabled = !AmbientLight.enabled;
        LongDistanceFlashLight.enabled = !LongDistanceFlashLight.enabled;
    }
    void setIntensity(float number)
    {
        Debug.Log(number);
        NearLight.intensity = nearLight_intensity * number;
        FlashLight.intensity = original_intensity * number;
        LongDistanceFlashLight.intensity = LongDistance_intensity * number;
    }
    void Update()
    {
        //Number of clips has to be even. First half are "turn on" sounds, Second half are "turn off" sounds.
        if (Input.GetButtonDown("Flashlight"))
        {
            if (FlashLight.enabled)
                Sound.clip = audioClips[rand.Next(audioClips.Length / 2, audioClips.Length)];
            else
                Sound.clip = audioClips[rand.Next(0, audioClips.Length / 2)];
            Sound.Play();
            isFlickering = false;
            switchLight();
        }

        if (FlashLight.enabled)
        {
            if (power > 0 && rand.Next(0, 1000) < dischargeSpeed)
            {
                power -= 1;
                //Debug.Log(power);
            }
        }
        if (power < flashlight_dies_at)
        {
            NearLight.intensity = 0;
            FlashLight.intensity = 0;
            LongDistanceFlashLight.intensity = 0;
            bodyLight.enabled = false;
            return;
        }
        if (flashlight_dies_at < power && power < start_flicker_at && rand.Next(0, 2000) == 1)
        {
            Debug.Log("Started flickering");
            buzzing.Play();
            isFlickering = true;
        }
        if (isFlickering)
        {
            int random = rand.Next(3, 10);
            int chance = rand.Next(1, 5000);
            if(chance >4500)
                setIntensity((float)random / 10);
            if (chance <10)
            {
                buzzing.Pause();
                Debug.Log("Stoped flickering");
                isFlickering = false;
            }
        }
    }
    public void Restore_Capacity()
    {
        NearLight.intensity = nearLight_intensity;
        FlashLight.intensity = original_intensity;
        LongDistanceFlashLight.intensity = LongDistance_intensity;
        bodyLight.enabled = true;
        if (power > 50)
            power = 100;
        else
            power += 50;
    }
}