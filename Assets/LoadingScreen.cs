using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public AudioSource sound;
    public GameObject screen;
    void Update()
    {
        if (!sound.isPlaying)
            screen.SetActive(false);
        else
            screen.SetActive(true);
    }
}
