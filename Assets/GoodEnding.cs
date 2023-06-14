using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class GoodEnding : MonoBehaviour
{
    public Core Core;
    public GameObject screen;

    // Update is called once per frame
    void Update()
    {
        if (isCloseToPlayer(transform))
        {
            Time.timeScale = 0;
            screen.SetActive(true);
            Core.DeathHUD.SetActive(true);
            ToggleCursor();
            this.gameObject.SetActive(false);
        }
    }
}
