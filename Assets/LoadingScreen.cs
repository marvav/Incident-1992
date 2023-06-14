using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public AudioSource sound;
    void Update()
    {
        if (!sound.isPlaying)
        {
            this.gameObject.SetActive(false);
        }
    }
}
