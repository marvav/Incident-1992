using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Archive;
public class ReadableNote : MonoBehaviour
{
    public Core Core;
    public string[] titles;
    public string[] contents;
    public int clueID;

    // Update is called once per frame
    public void PickUpNote()
    {
        Core.NoteText.GetComponent<TMP_Text>().text = GetContent();
        Core.Note.SetActive(true);
        Core.ProgressManager.changeObjective(clueID);
        Archive.Add(new NoteItem(titles, contents));
        this.gameObject.SetActive(false);
    }
    public string GetContent()
    {
        return contents[Core.GetLanguage()];
    }
}