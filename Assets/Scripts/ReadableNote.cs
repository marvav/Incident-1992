using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;
using static Archive;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string content;
    public float range = 1.0f;
    public int clueID;
    private bool isHidden = true;
    private bool inArchive;

    // Update is called once per frame
    void Update()
    {
        if (isCloseToPlayer(transform, range) && CanInteract(this.gameObject, range))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.NoteText.GetComponent<TMP_Text>().text = content;
                Core.Note.SetActive(true);
                Core.PickUpItem.SetActive(false);
                Core.ProgressManager.changeObjective(clueID);
                Archive.Add(new NoteItem(this.gameObject.name, content));
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