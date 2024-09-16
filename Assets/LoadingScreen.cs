using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public AudioSource sound;
    public GameObject screen;
    void Update()
    {
        screen.SetActive(sound.isPlaying);
    }
}
