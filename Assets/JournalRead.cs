using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class JournalRead : MonoBehaviour, IPointerClickHandler
{
    public Core Core;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1 || !Core.Note.gameObject.activeSelf)
        {
            Core.Description.text = "";
            Core.NoteText.GetComponent<TMP_Text>().text = Core.ProgressManager.getClues();
            Core.Note.SetActive(true);
        }
        else
        {
            Core.Note.SetActive(false);
        }
    }
}
