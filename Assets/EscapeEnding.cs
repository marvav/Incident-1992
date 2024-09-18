using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeEnding : MonoBehaviour
{
    public Core Core;
    public GameObject RopeEndingTextScene;
    // Start is called before the first frame update
    void Start()
    {
        RopeEndingTextScene.SetActive(true);
        Core.DeathManager.EscapeEndingScreen();
    }
}
