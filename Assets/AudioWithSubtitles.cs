using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWithSubtitles : MonoBehaviour
{
    public Core Core;
    public AudioSource source;
    public string[] subtitles;
    public float[] subtitlesTimes;
    public bool isClue;
    public ProgressManager ProgressManager;
    public int progressNumber;
    private int index;
    private float timer;
    private bool isPaused = false;

    void Start()
    {
        Core.Monster.ToggleMonster();
        source.Play();
        timer = 0.0f;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
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
            if (isClue)
                ProgressManager.changeObjective(progressNumber);
            Core.Subtitles.text = "";
            Core.Monster.ToggleMonster();
            this.gameObject.SetActive(false);
        }
    }
}
