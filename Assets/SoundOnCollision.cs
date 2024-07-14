using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioSource Sound;
    public string tag;
    public float triggerMagnitude;
    public float defaultPitch = 1.0f;
    public Core Core;

    void OnCollisionEnter(Collision collision)
    {

        //TODO tag hierarchy of sounds
        if (collision.gameObject.layer != 8 && collision.relativeVelocity.magnitude > triggerMagnitude)
        {
            Sound.Stop();
            Sound.clip = Core.EnvironmentCollisionSounds.getCollisionSound(this.gameObject.tag);
            Sound.pitch = Math.Max(defaultPitch - (0.025f * collision.relativeVelocity.magnitude),0.1f);
            Sound.Play();
        }
    }
}
