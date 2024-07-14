using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollisionSounds : MonoBehaviour
{
    public AudioClip asphalt;
    public Dictionary<string, int> tags = new Dictionary<string, int>();
    public Dictionary<int, AudioClip> sounds = new Dictionary<int, AudioClip>();

    void Start()
    {
        tags.Add("Asphalt", 3);
        sounds.Add(3, asphalt);
    }

    public AudioClip getCollisionSound(string tag)
    {
        //int tag1 = tags[collision.self.tag];
        int tag2 = tags[tag];
        return sounds[tag2];
    }
}
