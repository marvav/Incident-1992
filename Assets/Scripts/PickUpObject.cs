using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryAPI;
using CoreImport;

public class PickUpItem : MonoBehaviour
{
    public GameObject Inventory_Object;
    public GameObject PickUpText;
    private float PlayerHeight;
    private GameObject Player;
    private InventoryItems Inventory;
    // Start is called before the first frame update
    void Start()
    {
       // PlayerHeight = Player.GetComponent<PlayerMovementDen>().playerHeight;
        Inventory = Inventory_Object.GetComponent<InventoryItems>();
        Player = CoreImport.Object.Player;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight/2, 0), Player.transform.position) < 2)
        {
            PickUpText.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                InventoryAPI.Item item = new InventoryAPI.Item(this.gameObject.name);
                Inventory.Inventory.Add(item);
                this.gameObject.SetActive(false);
                PickUpText.SetActive(false);

            }
        }
        else
            PickUpText.SetActive(false);
    }
}
