using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core_Utils;

public class InteractionTeleport : MonoBehaviour
{
    public GameObject loadingScreen;
    public bool itemNeeded = true;
    public bool destroyAfterUse = false;
    public GameObject NeededItem;
    public string message;
    public float range = 2.0f;
    public Core Core;
    private bool isHidden = true;
    public GameObject Destination;

    void Update()
    {
        if (isCloseToPlayer(transform, range))
        {
            Core.Description.text = message;
            if ((!itemNeeded || Inventory.InHand == NeededItem.name) && Input.GetMouseButtonDown(0))
            {
                if (destroyAfterUse && itemNeeded)
                {
                    Inventory.InHand = "";
                    Inventory.Remove(NeededItem.name);
                    NeededItem.SetActive(false);
                }
                Core.Description.text = "";
                Player.transform.position = Destination.transform.position;
                if (loadingScreen != null)
                    loadingScreen.SetActive(true);
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
