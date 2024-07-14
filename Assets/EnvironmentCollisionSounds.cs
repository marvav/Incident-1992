using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollisionSounds : MonoBehaviour
{
    public AudioClip asphalt;
    public AudioClip iron;
    public Dictionary<string, int> tags = new Dictionary<string, int>();
    public Dictionary<int, AudioClip> sounds = new Dictionary<int, AudioClip>();

    void Start()
    {
        tags.Add("Asphalt", 3);
        tags.Add("Iron", 2);
        sounds.Add(3, asphalt);
        sounds.Add(2, iron);
    }

    public AudioClip getCollisionSound(string tag)
    {
        //int tag1 = tags[collision.self.tag];
        int tag2 = tags[tag];
        return sounds[tag2];
    }
}
