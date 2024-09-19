using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class AudioManager : MonoBehaviour
{
    public Core Core;
    public AudioSource GeneralMusic;
    public AudioSource GeneralAmbient;
    public AudioClip BadEndingMusic;
    public AudioClip CarEndingMusic;
    public AudioClip DepthEndingMusic;
    public AudioClip EscapeEndingMusic;
    public AudioClip MenuMusic;
    public AudioClip[] musicAutoplay;
    public int chanceToPlay;

    void Start()
    {
        GeneralAmbient.time = rand.Next(0, 1800);
        GeneralAmbient.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        PlayMusic(clip, false);
    }

    public void PlayMusic(AudioClip clip, bool loop)
    {
        StopMusic();
        GeneralMusic.loop = loop;
        GeneralMusic.clip = clip;
        GeneralMusic.Play();
    }

    public void StopMusic()
    {
        GeneralMusic.Stop();
    }

    void FixedUpdate()
    {
        if (Core.Monster.MonsterIsClose())
        {
            StopMusic();
            return;
        }
        if (!GeneralMusic.isPlaying && rand.Next(0, chanceToPlay) == 0)
        {
            PlayMusic(musicAutoplay[rand.Next(0, musicAutoplay.Length)]);
        }
    }
}
