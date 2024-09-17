using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using static Archive;
using static Core_Utils;


public class ArchiveRead : MonoBehaviour, IPointerClickHandler
{
    public Core Core;
    public GameObject ArchiveUI;
    public GameObject CloseTouchScreen;
    public GameObject[] notesUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            bool currentState = ArchiveUI.gameObject.activeSelf;
            for (int i = 0; i < notesUI.Length; i++)
            {
                if (Notes[i] == null)
                    break;
                notesUI[i].SetActive(!currentState);
            }
            CloseTouchScreen.SetActive(!currentState);
            ArchiveUI.SetActive(!currentState);
            Core.Description.text = "";
            Core.DescriptionUI.text = "";
            Core.Note.SetActive(false);
        }
    }
}
