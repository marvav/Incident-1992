using UnityEngine;
using System.Collections;
using System;

public class BreathingComponent : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource Sound;
    public System.Random rand;
    private float LastSoundTime;


    void Start()
    {
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
        LastSoundTime = Time.time;
}


    void Update()
    {
        //Number of clips has to be even. First half are "turn on" sounds, Second half are "turn off" sounds.
        if (rand.Next(0,5)==2 && (Time.time - LastSoundTime) > 2)
        {
            Sound.clip = audioClips[0];
            Sound.Play();
            LastSoundTime = Time.time;
        }
    }
}
