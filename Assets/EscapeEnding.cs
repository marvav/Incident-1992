using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeEnding : MonoBehaviour
{
    public Core Core;
    // Start is called before the first frame update
    void Start()
    {
        Core.StopPlayer();
        Core.DeathManager.EscapeEndingScreen();
    }
}
