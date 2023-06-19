using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;
using static Core_Utils;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    public float range = 1.0f;
    private float PlayerHeight;
    private bool isHidden = true;
    public bool isClue;
    public int clueID = 0;
    public Renderer renderer;

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && CanInteract(this.gameObject, range))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.Description.text = "";
                if (isClue)
                    Core.ProgressManager.changeObjective(clueID);
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
