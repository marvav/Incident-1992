using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollisionSounds : MonoBehaviour
{
    public AudioClip asphalt;
    public AudioClip iron;
    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    void Start()
    {
        sounds.Add("Asphalt", asphalt);
        sounds.Add("Iron", iron);
    }

    public AudioClip getCollisionSound(string tag)
    {
        //int tag1 = tags[collision.self.tag];
        return sounds[tag];
    }
}
