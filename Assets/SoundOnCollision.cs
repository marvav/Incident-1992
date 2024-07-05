using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioSource Sound;
    public string tag;
    public float triggerMagnitude;
    public float defaultPitch = 1;
    public bool ignorePlayer;
    public Core Core;

    void OnCollisionEnter(Collision collision)
    {
        if ((ignorePlayer && collision.gameObject.layer == 8))
        {
            return;
        }

        //TODO tag hierarchy of sounds
        if (collision.relativeVelocity.magnitude > triggerMagnitude)
        {
            if (Sound.isPlaying)
            {
                Sound.Stop();
                return;
            }
            Sound.pitch = defaultPitch - (0.05f * collision.relativeVelocity.magnitude);
            Sound.Play();
        }
    }
}
