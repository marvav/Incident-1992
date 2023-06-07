using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    public UnityEngine.UI.Image EndingScreen;
    public UnityEngine.UI.Image Background;
    public GameObject BadEndingMusic;
    private AudioSource m_MyAudioSource;
    private bool isHidden;
    private bool leaving;
    private float delay;
    void Start()
    {
        isHidden = true;
        leaving = false;
        delay = Time.realtimeSinceStartup;
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leaving)
        {
            Time.timeScale = 0;
            float t = Time.realtimeSinceStartup;
            if (t - delay > 0.01f && EndingScreen.color.a < 255)
            {
                var tempColor = EndingScreen.color;
                tempColor.a += 0.001f;
                EndingScreen.color = tempColor;
                tempColor = Background.color;
                tempColor.a += 0.002f;
                Background.color = tempColor;
                delay = t;
                if (EndingScreen.color.a>254)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (!leaving && Vector3.Distance(transform.position, Core.Player.transform.position) < 3)
        {
            Core.Description.text = "Drive Home";
            isHidden = false;
            if (Input.GetButton("Pick Up"))
            {
                leaving = true;
                m_MyAudioSource.Play();
                BadEndingMusic.SetActive(true);
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

    public void TriggerEnd()
    {
        m_MyAudioSource.Play();
        leaving = true;
        BadEndingMusic.SetActive(true);
    }
}