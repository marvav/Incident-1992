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
    private bool wasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (wasPlayed && !audioClip.isPlaying && !Sound.isPlaying)
        {
            ProgressManager.changeObjective(progressNumber);
            Sound.Play();
        }
        if(!wasPlayed && rand.Next(0,10000)==1)
        {
            Sound.Pause();
            audioClip.clip = recording;
            wasPlayed = true;
            audioClip.Play();
        }
    }
    public void NewRecording(AudioClip newClip, int newProgressNumber)
    {
        recording = newClip;
        progressNumber = newProgressNumber;
        wasPlayed = false;
    }
}