using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceRecordings : MonoBehaviour
{
    public ProgressManager ProgressManager;
    public AudioSource Sound;
    public AudioSource audioClip;
    public AudioClip recording;
    public System.Random rand;
    public int progressNumber;
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
        if (wasPlayed && !audioClip.isPlaying && !Sound.isPlaying)
        {
            Sound.Play();
        }
        if(!wasPlayed && rand.Next(0,2000)==1)
        {
            Sound.Pause();
            audioClip.clip = recording;
            wasPlayed = true;
            audioClip.Play();
            ProgressManager.changeObjective(progressNumber);
        }
    }
    public void NewRecording(AudioClip newClip, int newProgressNumber)
    {
        recording = newClip;
        progressNumber = newProgressNumber;
        wasPlayed = false;
    }
}
