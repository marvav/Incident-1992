using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class ToggleObject : MonoBehaviour
{
    public Core Core;
    public AudioClip sound;
    public GameObject icon;
    public GameObject[] objects;
    public GameObject[] objectsToSwap;
    public GameObject neededItem;
    public bool isOneTime = false;
    public bool destroyAfterUse = false;
    private bool wasUsed = false;

    public void Toggle()
    {
        if (wasUsed && isOneTime)
            return;

        if (neededItem && Inventory.InHand == neededItem)
        {
            if (destroyAfterUse)
                Inventory.Remove(Inventory.InHand.name);
            Inventory.InHand = null;
            PerformToggle();
        }

        if (!neededItem)
        {
            //isOn = !isOn;
            PerformToggle();
        }

        if (isOneTime)
        {
            neededItem.SetActive(false);
        }
    }

    void PerformToggle()
    {
        if (objects.Length > 0)
        {
            bool isOn = objects[0].activeSelf;
            ToggleObjects(objects, !isOn);
            ToggleObjects(objectsToSwap, isOn);
            if (sound)
            {
                Core.GeneralAudio.Stop();
                Core.GeneralAudio.clip = sound;
                Core.GeneralAudio.Play();
            }
        }
    }
}
