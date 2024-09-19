using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PlayerInit : MonoBehaviour
{
    public Core Core;

    void OnEnable()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
