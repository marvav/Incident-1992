using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject self;
    public GameObject Player;
    public GameObject Inventory_Object;
    public GameObject PickUpText;
    public string item_name;
    private float PlayerHeight;
    private HashSet<string> Inventory;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHeight = Player.GetComponent<CharacterController>().height;
        Inventory = Inventory_Object.GetComponent<InventoryItems>().Items;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight/2, 0), Player.transform.position) < 2)
        {
            PickUpText.SetActive(true);
            if(Input.GetButton("Pick Up"))
            {
                Inventory.Add(item_name);
                self.SetActive(false);
                PickUpText.SetActive(false);

            }
        }
        else
            PickUpText.SetActive(false);
    }
}
