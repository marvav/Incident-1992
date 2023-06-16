using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWithSubtitles : MonoBehaviour
{
    public Core Core;
    public AudioSource source;
    public string[] subtitles;
    public float[] subtitlesTimes;
    private int index = 0;
    private float timer = 0.0f;
    private bool wasPlayed = false;

    void Start()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (source.isPlaying)
        {
            timer += Time.deltaTime;
            if(index < subtitles.Length && timer > subtitlesTimes[index])
            {
                Core.Description.text = subtitles[index];
                index++;
            }

        }
        else
        {
            Core.Description.text = "";
            this.gameObject.SetActive(false);
        }
    }
}
