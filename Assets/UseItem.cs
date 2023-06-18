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
    public string message;
    public float range = 2.0f;
    public Core Core;
    private bool isHidden = true;

    // Update is called once per frame
    void Update()
    {
        if (isCloseToPlayer(transform, range))
        {
            Core.Description.text = message;
            if ((!itemNeeded || Inventory.InHand == NeededItem) && Input.GetMouseButtonDown(0))
            {
                if (destroyAfterUse && itemNeeded)
                {
                    Inventory.InHand = null;
                    Inventory.Remove(NeededItem.name);
                    NeededItem.SetActive(false);
                }
                Core.Description.text = "";
                MovedObject.SetActive(true);
                ObjectToMove.SetActive(false);
            }
            isHidden = false;
        }
        else
        {
            if (!isHidden)
            {
                Core.Description.text = "";
                isHidden = true;
            }
        }
    }
}
