using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;
using static Core_Utils;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    private bool isHidden;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Item item = new Item(this.gameObject.name);
                Inventory.Add(item);
                Core.PickUpSound.Play();
                Core.PickUpItem.SetActive(false);
                this.gameObject.SetActive(false);
                return;
            }
        }
        else
        {
            if(!isHidden)
            {
                Core.PickUpItem.SetActive(false);
                isHidden = true;
            }
        }
    }
}
