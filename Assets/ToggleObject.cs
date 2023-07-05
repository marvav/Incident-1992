using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ToggleObject : MonoBehaviour
{
    public Core Core;
    public AudioClip sound;
    public GameObject[] objects;
    public GameObject[] objectsToSwap;
    public bool isOn = false;

    public void Toggle()
    {
        isOn = !isOn;
        ToggleObjects(objects, isOn);
        ToggleObjects(objectsToSwap, !isOn);
        Core.GeneralAudio.clip = sound;
        Core.GeneralAudio.Play();
    }
}
