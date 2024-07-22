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

    void Start()
    {
        Time.timeScale = 1;
        ToggleCursor();
        if(music != null)
        {
            Core.AudioManager.PlayMusic(music, true);
        }
        queue = lines[start];
        resetQueue();
        StartCoroutine(write());
    }

    IEnumerator write()
    {
        while (queue.Length > queueIndex)
        {
            text.text += queue[queueIndex];
            queueIndex++;
            if (text.text.Length > 1 && text.text[text.text.Length - 1] == ' ' && text.text[text.text.Length - 2] == '.')
            {
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        stop();
    }

    void resetQueue()
    {
        queueIndex = 0;
        text.text = "";
    }

    void stop()
    {
        sound.Play();
        if (endLoopMusic)
            Core.AudioManager.GeneralMusic.loop = false;
        text.text = "";
        ToggleObjects(TurnOnAfter, true);
        ToggleObjects(TurnOffAfter, false);
        this.gameObject.SetActive(false);
    }
}
