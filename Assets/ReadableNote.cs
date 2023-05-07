using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string content;
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
        if (Vector3.Distance(transform.position + new Vector3(0, PlayerHeight, 0), Player.transform.position) < 1.5f 
            || Vector3.Distance(transform.position, Player.transform.position) < 1.5f)
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.NoteText.GetComponent<TMP_Text>().text = content;
                Core.Note.SetActive(true);
                Core.PickUpItem.SetActive(false);
                return;
            }
        }
        else
        {
            if (!isHidden)
            {
                Core.PickUpItem.SetActive(false);
                isHidden = true;
            }
        }
    }
}