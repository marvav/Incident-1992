using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAfterSound : MonoBehaviour
{
    public AudioSource sound;
    private bool hasPlayed = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasPlayed && !sound.isPlaying)
        {
            this.gameObject.SetActive(false);
        }
        if (!hasPlayed)
        {
            sound.Play();
            hasPlayed = true;
        }
    }
}
