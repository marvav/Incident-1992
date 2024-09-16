using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource GeneralMusic;
    public AudioClip BadEndingMusic;
    public AudioClip CarEndingMusic;
    public AudioClip DepthEndingMusic;
    public AudioClip EscapeEndingMusic;

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
}
