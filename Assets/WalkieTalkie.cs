using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using static Core_Utils;

public class WalkieTalkie : MonoBehaviour
{
    public Core Core;
    public ProgressManager ProgressManager;
    public AudioSource buzzingSource;
    public AudioClip[] Buzz;
    public AudioClip[] VoiceOver;
    private int index = 0;
    private int progressNumber;
    private bool wasPlayed = true;
    private List<GameObject> recordings;

    void Start()
    {
        recordings = CountChildren(this.gameObject);
    }

    void Update()
    {
        if(!wasPlayed && !buzzingSource.isPlaying && rand.Next(0,2000) == 1)
        {
            buzzingSource.clip = Buzz[rand.Next(0, Buzz.Length)];
            buzzingSource.Play();
            Core.VoiceOver.clip = VoiceOver[rand.Next(0, VoiceOver.Length)];
            Core.VoiceOver.Play();
        }
    }

    public void NewRecording(int newProgressNumber)
    {
        progressNumber = newProgressNumber;
        wasPlayed = false;
        index++;
    }

    public void PlayRecording()
    {
        wasPlayed = true;
        recordings[index].SetActive(true);
        ProgressManager.changeObjective(progressNumber);
    }
}
