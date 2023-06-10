using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;
using static Archive;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string title;
    public string content;
    public int clueID;
    private bool isHidden;
    private bool inArchive;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.NoteText.GetComponent<TMP_Text>().text = content;
                Core.Note.SetActive(true);
                Core.PickUpItem.SetActive(false);
                Core.ProgressManager.changeObjective(clueID);
                Archive.Add(new NoteItem(title, content));
                this.gameObject.SetActive(false);
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