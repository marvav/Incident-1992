using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryAPI;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    private InventoryItems Inventory;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerHeight = Player.GetComponent<PlayerMovementDen>().playerHeight;
        PlayerHeight = 2;
        Inventory = Core.Inventory.GetComponent<InventoryItems>();
        Player = Core.Player;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight/2, 0), Player.transform.position) < 2)
        {
            Core.PickUpText.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Item item = new Item(this.gameObject.name);
                Inventory.Inventory.Add(item);
                this.gameObject.SetActive(false);
                Core.PickUpText.SetActive(false);

            }
        }
        else
            Core.PickUpText.SetActive(false);
    }
}
