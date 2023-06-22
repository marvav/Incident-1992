using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;
using static Core_Utils;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    private bool isHidden = true;
    public int clueID = 0;

    // Update is called once per frame
    void Update()
    {
        if (CanInteract(this.gameObject, 2.0f, 35.0f))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.Description.text = "";
                Core.ProgressManager.changeObjective(clueID);
                Item item = new Item(this.gameObject.name);
                Inventory.Add(item);
                Core.PickUpSound.Play();
                Core.PickUpItem.SetActive(false);
                this.gameObject.SetActive(false);
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
