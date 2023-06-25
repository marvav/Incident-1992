using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;
using static Archive;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string[] titles;
    public string content;
    public string[] contents;
    public int clueID;
    private bool isHidden = true;

    // Update is called once per frame
    void Update()
    {
        if (CanInteract(this.gameObject, 1.0f, 35.0f))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Core.NoteText.GetComponent<TMP_Text>().text = contents[Core.GetLanguage()];
                Core.Note.SetActive(true);
                Core.PickUpItem.SetActive(false);
                Core.ProgressManager.changeObjective(clueID);
                Archive.Add(new NoteItem(titles, contents));
                this.gameObject.SetActive(false);
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