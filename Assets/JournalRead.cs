using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class JournalRead : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Core Core;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = "Journal";
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
            Core.NoteText.GetComponent<TMP_Text>().text = Core.ProgressManager.getClues();
            Core.Note.SetActive(true);
        }
    }
}
