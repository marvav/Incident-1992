using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class UseItem : MonoBehaviour
{
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public bool itemNeeded = true;
    public bool destroyAfterUse = false;
    public GameObject NeededItem;
    public string[] description;

    public void Use()
    {
        if ((!itemNeeded || Inventory.InHand == NeededItem))
        {
            if (destroyAfterUse && itemNeeded)
                Inventory.Remove(NeededItem.name);
            Inventory.InHand = null;
            NeededItem.SetActive(false);
            MovedObject.SetActive(true);
            ObjectToMove.SetActive(false);
        }
    }
}
