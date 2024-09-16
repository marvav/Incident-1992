using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Core Core;
    public string text;
    public GameObject Scene;
    public string text2;

    void Update()
    {
        if (!Core.DeathManager.isScreenShown())
        {
            Core.RollingText.RollText(text2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic);
        Core.RollingText.RollText(text);
        Core.StopPlayer();
        Core.DeathManager.GoodEndingScreen();
    }
}
