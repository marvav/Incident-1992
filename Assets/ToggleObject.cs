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
    public bool isOn = false;
    public bool isOneTime = false;
    public bool destroyAfterUse = false;
    private bool wasUsed = false;

    public void Toggle()
    {
        if (wasUsed && isOneTime)
            return;

        if(!neededItem || Inventory.InHand == neededItem)
        {
            if(neededItem && Inventory.InHand == neededItem)
            {
                if (destroyAfterUse)
                    Inventory.Remove(Inventory.InHand.name);
                Inventory.InHand = null;
            }
            //isOn = !isOn;

            if (objects.Length != 0)
            {
                isOn = objects[0].activeSelf;
                ToggleObjects(objects, !isOn);
                ToggleObjects(objectsToSwap, isOn);
                if (sound)
                {
                    Core.GeneralAudio.clip = sound;
                    Core.GeneralAudio.Play();
                }
            }
        }
        if (isOneTime)
        {
            if (neededItem != null)
            {
                neededItem.SetActive(false);
                Inventory.InHand = null;
            }
        }
    }
}
