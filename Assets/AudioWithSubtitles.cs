using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWithSubtitles : MonoBehaviour
{
    public Core Core;
    public AudioSource source;
    public string[] subtitles;
    public float[] subtitlesTimes;
    public ProgressManager ProgressManager;
    public int progressNumber = 0;
    private int index = 0;
    private int charIndex = 0; 
    private float timer = 0.0f;
    private bool isPaused = false;

    void Start()
    {
        Core.Monster.ToggleMonster();
        source.Play();
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
            timer += Time.deltaTime;
            if (isPaused)
            {
                isPaused = false;
                source.UnPause();
            }
            else
            {
                if (index < subtitles.Length && timer > subtitlesTimes[index])
                {
                    Core.Subtitles.text = subtitles[index];
                    index++;
                }
            }

        }
        else
        {
            ProgressManager.changeObjective(progressNumber);
            Core.Subtitles.text = "";
            Core.Monster.ToggleMonster();
            this.gameObject.SetActive(false);
        }
    }
}
