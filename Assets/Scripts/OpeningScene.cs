using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class OpeningScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Core Core;
    public TMP_Text text;
    public AudioSource sound;
    public AudioClip music;
    public string[] lines;
    public bool endLoopMusic = true;
    private int start = 1;
    private bool isHidden = true;
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
        text.text = lines[0];
    }
    void Update()
    {
        if(isHidden && Input.GetMouseButtonDown(0))
        {
            sound.Play();
            if (start >= lines.Length-1)
            {
                if(endLoopMusic)
                    Core.GeneralMusic.loop = false;
                text.text = "";
                this.gameObject.SetActive(false);
                return;
            }
            text.text = lines[start];
            start++;
            isHidden = false;
        }
        else
        {
            isHidden = true;
        }
    }
}
