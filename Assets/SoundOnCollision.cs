using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollision : MonoBehaviour
{
    public AudioSource Sound;
    public Core Core;

    void Start()
    {
        Sound.volume = 0.0f; // To not make noise on startup
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8 && collision.relativeVelocity.magnitude > Core.EnvironmentCollisionSounds.getTriggerVelocity(this.gameObject.tag))
        {
            Sound.Stop();
            Core.EnvironmentCollisionSounds.setupAudio(Sound, this.gameObject.tag, collision.relativeVelocity.magnitude);
            Sound.volume = Core.GeneralAudio.volume;
            Sound.Play();
        }
    }
}
