using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class MusicPlayer : MonoBehaviour
{
    public Core Core;
    public AudioClip[] music;
    public AudioSource audioSource;
    public int delay = 1;

    void FixedUpdate()
    {
        if (Core.Monster.MonsterIsClose())
        {
            audioSource.Stop();
            return;
        }
        if (!audioSource.isPlaying && rand.Next(0, delay) == 0)
        {
            audioSource.clip = music[rand.Next(0, music.Length)];
            audioSource.Play();
        }
    }
}
