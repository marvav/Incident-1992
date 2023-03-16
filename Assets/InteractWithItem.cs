using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class InteractWithItem : MonoBehaviour
{
    public Core Core;
    public GameObject Interactable_item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Inventory.InHand == Interactable_item.name)
            {
                Debug.Log("You unlocked this chest");
                Core.ItemInHand.SetActive(false);
                Inventory.Remove(Interactable_item.name);
                Inventory.InHand = null;
            }

        }
    }
}
