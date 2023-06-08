using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecordings : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip audioClip;
    public System.Random rand;
    private bool wasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        wasPlayed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!wasPlayed && rand.Next(0,2000)==1)
        {
            Sound.clip = audioClip;
            wasPlayed = true;
            Sound.Play();
        }
    }
    void NewRecording(AudioClip newClip)
    {
        audioClip = newClip;
        wasPlayed= false;
    }
}
