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

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.DescriptionUI.text = Notes[ArchiveIndex].titles[Core.GetLanguage()];
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.DescriptionUI.text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            Core.DescriptionUI.text = "";
            Core.NoteText.GetComponent<TMP_Text>().text = Notes[ArchiveIndex].contents[Core.GetLanguage()];
            Core.Note.SetActive(true);
        }
    }
}
