using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Archive;


public class ReadNoteInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int ArchiveIndex;
    public Core Core;
    private bool isOpen;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = Notes[ArchiveIndex].name;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.Description.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            Core.Description.text = "";
            Core.NoteText.GetComponent<TMP_Text>().text = Notes[ArchiveIndex].content;
            Core.Note.SetActive(true);
        }
    }
}
