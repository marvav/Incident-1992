using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class BadEnding : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    public GameObject CarEnding;
    public UnityEngine.UI.Image BadEndingScreen;
    public UnityEngine.UI.Image Background;
    public AudioSource CarAudio;
    private UnityEngine.UI.Image screen;
    private bool isHidden;
    private bool leaving;
    private float delay;
    void Start()
    {
        isHidden = true;
        leaving = false;
        delay = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (leaving)
        {
            Time.timeScale = 0;
            float t = Time.realtimeSinceStartup;
            if (t - delay > 0.01f && screen.color.a < 255)
            {
                var tempColor = screen.color;
                tempColor.a += 0.001f;
                screen.color = tempColor;
                tempColor = Background.color;
                tempColor.a += 0.002f;
                Background.color = tempColor;
                delay = t;
                if (screen.color.a > 250)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (Core.ProgressManager.noteFound && !leaving && isCloseToPlayer(transform))
            {
                Core.Description.text = "Drive Home";
                isHidden = false;
                if (Input.GetButton("Pick Up"))
                {
                    CarEnding.SetActive(true);
                    screen = BadEndingScreen;
                    leaving = true;
                    CarAudio.Play();
                    Core.DeathHUD.SetActive(true);
                }
            }
            else
            {
                if (!isHidden)
                {
                    Core.Description.text = "";
                    isHidden = true;
                }
            }
        }
    }
}