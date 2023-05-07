using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class PickUpItem : MonoBehaviour
{
    public Core Core;
    private float PlayerHeight;
    private GameObject Player;
    private bool isHidden;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerHeight = Player.GetComponent<PlayerMovementDen>().playerHeight;
        PlayerHeight = 2;
        Player = Core.Player;
        isHidden = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight/2, 0), Player.transform.position) < 1.5f)
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Item item = new Item(this.gameObject.name);
                Inventory.Add(item);
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
