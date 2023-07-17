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
    public bool noToggle = false;

    public void Toggle()
    {
        if (wasUsed && isOneTime)
            return;
        if(neededItem==null || Inventory.InHand == neededItem)
        {
            if(Inventory.InHand == neededItem)
                Inventory.InHand = null;
            isOn = !isOn;
            ToggleObjects(objects, isOn);
            ToggleObjects(objectsToSwap, !isOn);
            Core.GeneralAudio.clip = sound;
            Core.GeneralAudio.Play();
        }
        if (noToggle)
            isOn = false;
        if (isOneTime)
        {
            if (neededItem != null)
            {
                neededItem.SetActive(false);
                Inventory.InHand = null;
            }
            if(destroyAfterUse)
                Inventory.Remove(Inventory.InHand.name);
        }
    }
}
