using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class ShootLock : MonoBehaviour
{
    public GameObject ObjectToMove;
    public ProgressManager ProgressManager;
    public GameObject MovedObject;
    public string NeededItem;
    public string message;
    public string messageCannot;
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
                if(ProgressManager.ammoAquired)
                {
                    Core.Description.text = "";
                    sound.Play();
                    MovedObject.SetActive(true);
                    ObjectToMove.SetActive(false);
                }
                else
                {
                    Core.Description.text = messageCannot;
                }
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
