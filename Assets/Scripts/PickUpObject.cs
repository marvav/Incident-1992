using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    public int clueID = 0;
    public void PutItemInInventory()
    {
        Inventory.Add(this.gameObject.name);
        Core.ProgressManager.changeObjective(clueID);
        Core.PickUpSound.Play();
        this.gameObject.SetActive(false);
    }
}
