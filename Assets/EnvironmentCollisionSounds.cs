using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollisionSounds : MonoBehaviour
{
    public AudioClip asphalt;
    public AudioClip iron;
    public AudioClip water;
    public float asphaltPitch;
    public float ironPitch;
    public float waterPitch;
    public float asphaltTriggerVelocity;
    public float ironTriggerVelocity;
    public float waterTriggerVelocity;

    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    private Dictionary<string, float> pitchs = new Dictionary<string, float>();
    private Dictionary<string, float> triggers = new Dictionary<string, float>();

    void Start()
    {
        sounds.Add("Asphalt", asphalt);
        sounds.Add("Iron", iron);
        sounds.Add("Water", water);
        pitchs.Add("Asphalt", asphaltPitch);
        pitchs.Add("Iron", ironPitch);
        pitchs.Add("Water", waterPitch);
        triggers.Add("Asphalt", asphaltTriggerVelocity);
        triggers.Add("Iron", ironTriggerVelocity);
        triggers.Add("Water", waterTriggerVelocity);
    }

    public float getTriggerVelocity(string tag)
    {
        return triggers[tag];
    }

    public void setupAudio(AudioSource audioSource, string tag, float magnitude)
    {
        audioSource.clip = sounds[tag];
        audioSource.pitch = Math.Max(pitchs[tag] - (0.025f * magnitude), 0.1f);
    }
}
