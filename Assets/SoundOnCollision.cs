using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioSource Sound;
    public float triggerMagnitude;
    public bool ignorePlayer;
    public Core Core;

    void OnCollisionEnter(Collision collision)
    {
        if (Sound.isPlaying || (ignorePlayer && collision.gameObject.layer == 8))
            return;

        if(collision.relativeVelocity.magnitude > triggerMagnitude)
            Sound.Play();
    }
}
