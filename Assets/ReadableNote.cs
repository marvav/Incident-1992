using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string content;
    private float PlayerHeight;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHeight = 2;
        Player = Core.Player;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight/2, 0), Player.transform.position) < 2)
        {
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.Note.SetActive(true);
                this.gameObject.SetActive(false);
                Core.PickUpItem.SetActive(false);
            }
        }
        else
        {
            Core.PickUpItem.SetActive(false);
        }
    }
}