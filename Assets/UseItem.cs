using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class UseItem : MonoBehaviour
{
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public string NeededItem;
    public string message;
    public AudioSource sound;
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
            if (Inventory.InHand == NeededItem && Input.GetMouseButtonDown(0))
            {
                Core.Description.text = "";
                sound.Play();
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
