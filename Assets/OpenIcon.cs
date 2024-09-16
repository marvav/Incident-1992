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
    public bool isOpen = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount > 0)
        {
            ForceClickAction();
        }
    }

    public void ForceClickAction()
    {
        if (sound)
        {
            sound.Play();
        }
        isOpen = !isOpen;
        ToggleObjects(alwaysOn, true);
        ToggleObjects(turnOn, isOpen);
        ToggleObjects(turnOff, !isOpen);
        ToggleObjects(alwaysOff, false);
        if (exitUI)
        {
            ToggleCursor();
            Time.timeScale = 1;
        }
    }
}
