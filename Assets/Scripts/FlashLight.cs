using UnityEngine;
using System.Collections;
using System;
using TMPro;
using static Core_Utils;

public class FlashLightComponent : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource buzzing;
    private AudioSource Sound;
    public int start_flicker_at;
    public Light LongDistanceFlashLight;
    public Light FlashLight;
    public Light NearLight;
    public Light bodyLight;
    public float dimmedBodyLight;
    private bool isFlickering;
    public int power = 100;
    public int dischargeSpeed;
    private float original_intensity;
    private float nearLight_intensity;
    private float LongDistance_intensity;
    private float bodyLight_intensity;

    void Start()
    {
        original_intensity = FlashLight.intensity;
        nearLight_intensity = NearLight.intensity;
        LongDistance_intensity = LongDistanceFlashLight.intensity;
        bodyLight_intensity = bodyLight.intensity;
        Sound = GetComponent<AudioSource>();
    }
    void switchLight()
    {
        if (NearLight.enabled)
            bodyLight.intensity = dimmedBodyLight;
        else
            bodyLight.intensity = bodyLight_intensity;
        NearLight.enabled = !NearLight.enabled;
        FlashLight.enabled = !FlashLight.enabled;
        LongDistanceFlashLight.enabled = !LongDistanceFlashLight.enabled;
    }
    void setIntensity(float number)
    {
        NearLight.intensity = nearLight_intensity * number;
        FlashLight.intensity = original_intensity * number;
        LongDistanceFlashLight.intensity = LongDistance_intensity * number;
    }
    void FixedUpdate()
    {
        if (FlashLight.enabled && power > 0 && rand.Next(0, 1000) < dischargeSpeed)
            power -= 1;

        if (power == 0)
        {
            NearLight.intensity = 0;
            FlashLight.intensity = 0;
            LongDistanceFlashLight.intensity = 0;
            bodyLight.intensity = dimmedBodyLight;
            isFlickering = false;
            buzzing.Pause();
        }
        if (0 < power)
        {

            if (power < start_flicker_at && rand.Next(0, 2000) == 1)
            {
                //Debug.Log("Started flickering");
                buzzing.Play();
                isFlickering = true;
            }
            if (isFlickering)
            {
                int random = rand.Next(3, 10);
                int chance = rand.Next(1, 5000);
                if (chance > 4500)
                    setIntensity((float)random / 10);
                if (chance < 10)
                {
                    buzzing.Pause();
                    //Debug.Log("Stoped flickering");
                    isFlickering = false;
                }
            }
        }
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
            buzzing.Pause();
            switchLight();
        }
    }
    public void Restore_Capacity()
    {
        isFlickering = false;
        buzzing.Pause();
        NearLight.intensity = nearLight_intensity;
        FlashLight.intensity = original_intensity;
        LongDistanceFlashLight.intensity = LongDistance_intensity;
        bodyLight.intensity = bodyLight_intensity;
        if (power > 50)
            power = 100;
        else
            power += 50;
    }
}