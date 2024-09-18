using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PlayerInit : MonoBehaviour
{
    public Core Core;

    void Start()
    {
        Time.timeScale = 1;
        ToggleCursor();
    }
}
