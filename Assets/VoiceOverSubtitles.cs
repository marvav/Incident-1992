using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverSubtitles : MonoBehaviour
{
    public Core Core;
    public AudioSource source;
    private string[] subtitles;
    private float[] subtitlesTimes;
    private bool isClue;
    private int progressNumber;
    private int index;
    private float timer;
    public bool isRunning = false;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (Time.timeScale == 0)
            {
                source.Pause();
                isPaused = true;
                return;
            }
            if (source.isPlaying || isPaused)
            {
                if (isPaused)
                {
                    isPaused = false;
                    source.UnPause();
                }
                timer += Time.deltaTime;
                if (index < subtitles.Length && timer > subtitlesTimes[index])
                {
                    Core.Subtitles.text = subtitles[index];
                    index++;
                }

            }
            else
            {
                Core.ProgressManager.changeObjective(progressNumber);
                Core.Subtitles.text = "";
                Core.Monster.ToggleMonster();
                isRunning = false;
            }
        }
    }
    public void InitiateVoiceOver(AudioClip record, string[] subtitles, float[] timestamps, int progressNumber)
    {
        Core.Monster.ToggleMonster();
        timer = 0.0f;
        index = 0;
        isRunning = true;
        source.clip = record;
        source.Play();
        this.subtitles = subtitles;
        subtitlesTimes = timestamps;
        this.progressNumber = progressNumber;
    }
}
