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
    public bool endLoopMusic = true;
    private int start = 0;
    private bool isClicked = false;
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
        text.text = lines[start];
    }

    void Update()
    {
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
            text.text = lines[start];
            isClicked = true;
        }
        else
            isClicked = false;
    }
}
