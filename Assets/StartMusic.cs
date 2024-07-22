using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public Core Core;
    public AudioClip music;

    void Start()
    {
        Core.AudioManager.PlayMusic(music);
    }
}
