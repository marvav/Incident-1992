using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class PauseGame : MonoBehaviour
{
    public GameObject EscapeMenu;
    public GameObject Inventory;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                EscapeMenu.SetActive(false);
                ToggleCursor();

            }
            else
            {
                Time.timeScale = 0;
                EscapeMenu.SetActive(true);
                ToggleCursor();
            }
        }
    }
}
