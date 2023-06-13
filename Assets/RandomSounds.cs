using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public AudioClip[] audioClips;
    public int rate;
    private AudioSource Sound;
    public System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sound.isPlaying && rand.Next(0, rate) == 1)
        {
            Sound.clip = audioClips[rand.Next(0, audioClips.Length)];
            Sound.Play();
        }


    }
}
