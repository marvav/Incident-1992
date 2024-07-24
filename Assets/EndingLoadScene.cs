using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;
using static Inventory;

public class EndingLoadScene : MonoBehaviour
{
    public Core Core;
    public AudioSource sound;
    public AudioSource LoadingScreen;
    public GameObject Teleport;
    public GameObject[] turnOn;
    public GameObject[] turnOff;
    public string[] lines;
    private int start = 0;

    void Start()
    {
        LoadingScreen.Play();
        ToggleObjects(turnOn, true);
    }
    void LateUpdate()
    {
        if (!Core.RollingText.isWriting())
        {
            if (start >= lines.Length)
            {
                Core.Player.transform.position = Teleport.transform.position;
                ToggleObjects(turnOff, false);
                this.gameObject.SetActive(false);
                return;
            }
            Core.RollingText.RollText(lines[start], 0, 0.0f);
            start++;
        }
    }
}
