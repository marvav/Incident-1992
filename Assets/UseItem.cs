using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class UseItem : MonoBehaviour
{
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public bool destroyAfterUse = false;
    public GameObject NeededItem;
    public string message;
    public Core Core;
    private bool isHidden;
    void Start()
    {
        isHidden = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            Core.Description.text = message;
            if (Inventory.InHand == NeededItem.name && Input.GetMouseButtonDown(0))
            {
                if (destroyAfterUse)
                {
                    Inventory.InHand = "";
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
