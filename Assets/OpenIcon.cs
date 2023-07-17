using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core_Utils;

public class OpenIcon : MonoBehaviour, IPointerClickHandler
{
    public AudioSource sound;
    public bool exitUI = false;
    public GameObject[] alwaysOn;
    public GameObject[] turnOn;
    public GameObject[] turnOff;
    public GameObject[] alwaysOff;
    private bool isOpen;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            sound.Play();
            ToggleObjects(alwaysOn, true);
            if (turnOn.Length != 0)
            {
                isOpen = turnOn[0].activeSelf;
                ToggleObjects(turnOn, !isOpen);
                ToggleObjects(turnOff, isOpen);
            }
            ToggleObjects(alwaysOff, false);
            if (exitUI)
            {
                ToggleCursor();
                Time.timeScale = 1;
            }

        }
    }
}
