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
    private bool isActive = false;
    public GameObject Destination;
    public AudioSource MovementSound;

    void FixedUpdate()
    {
        if (isCloseToPlayer(transform, range))
        {
            Core.Description.text = message;
            if ((!itemNeeded || Inventory.InHand == NeededItem) && Input.GetMouseButtonDown(0))
            {
                MovementSound.Play();
                Core.Player.transform.position = Destination.transform.position;
                if (destroyAfterUse && itemNeeded)
                {
                    Inventory.InHand = null;
                    Inventory.Remove(NeededItem.name);
                    NeededItem.SetActive(false);
                }
                Core.Description.text = "";
                return;
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
