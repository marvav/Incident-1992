using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public AudioClip[] audioClips;
    private System.Random rand;
    private AudioSource Sound;

    void Start()
    {
        Sound = GetComponent<AudioSource>();
        rand = new System.Random();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sound.clip = audioClips[rand.Next(0, audioClips.Length)];
            this.gameObject.SetActive(false);
            return;
        }
    }
}
