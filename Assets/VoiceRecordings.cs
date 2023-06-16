using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class VoiceRecordings : MonoBehaviour
{
    public ProgressManager ProgressManager;
    public AudioSource Sound;
    public AudioSource audioClip;
    public AudioClip recording;
    public int progressNumber;
    private bool wasPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (wasPlayed && !audioClip.isPlaying && !Sound.isPlaying)
        {
            ProgressManager.changeObjective(progressNumber);
            Sound.Play();
        }
        if(!wasPlayed)
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
