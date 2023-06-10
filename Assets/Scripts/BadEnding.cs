using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    public GameObject DeathControls;
    public UnityEngine.UI.Image BadEndingScreen;
    public UnityEngine.UI.Image GoodEndingScreen;
    public UnityEngine.UI.Image GreatEndingScreen;
    public UnityEngine.UI.Image Background;
    public AudioSource m_MyAudioSource;
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

    // Update is called once per frame
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
                if (screen.color.a>250)
                {
                    Debug.Log("konec");
                    DeathControls.SetActive(true);
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
                if (Core.ProgressManager.secondRecordingListened)
                {
                    if (Core.ProgressManager.vanSabotaged)
                        screen = GreatEndingScreen;
                    else
                        screen = GoodEndingScreen;
                }
                else
                    screen = BadEndingScreen;
                leaving = true;
                CarAudio.Play();
                m_MyAudioSource.Play();
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