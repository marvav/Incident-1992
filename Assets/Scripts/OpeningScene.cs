using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Core Core;
    public GameObject[] TurnOnAfter;
    public GameObject[] TurnOffAfter;
    public TMP_Text text;
    public AudioSource sound;
    public AudioClip music;
    public string[] lines;
    public float writingSpeed = 1.0f;
    public bool endLoopMusic = true;
    private int start = 0;
    private bool isClicked = false;

    private string queue = "";
    private int queueIndex = 0;
    private float queueTime = 0.0f;
    private float pile = 0.0f;
    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 1;
        ToggleCursor();
        if(music != null)
        {
            Core.GeneralMusic.clip = music;
            Core.GeneralMusic.Play();
            Core.GeneralMusic.loop = true;
        }
        queue = lines[start];
        resetQueue();
    }

    void Update()
    {
        if(queue.Length > queueIndex)
        {
            if(queueTime > 0)
            {
                pile += Time.deltaTime;
                if (pile >= writingSpeed)
                {
                    pile -= writingSpeed;
                    queueTime -= writingSpeed;
                    text.text += queue[queueIndex];
                    queueIndex++;
                }
            }
        }
        if(!isClicked && Input.GetMouseButtonDown(0))
        {
            sound.Play();
            start++;
            if (start == lines.Length)
            {
                if(endLoopMusic)
                    Core.GeneralMusic.loop = false;
                text.text = "";
                ToggleObjects(TurnOnAfter, true);
                ToggleObjects(TurnOffAfter, false);
                this.gameObject.SetActive(false);
                return;
            }
            queue = lines[start];
            resetQueue();
            isClicked = true;
        }
        else
            isClicked = false;
    }
    void resetQueue()
    {
        queueIndex = 0;
        queueTime = queue.Length * writingSpeed;
        text.text = "";
    }
}
