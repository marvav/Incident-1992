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
    private List<GameObject> icons;
    private bool isOpen = false;

    public void Start()
    {
        icons = CountChildren(ArchiveUI);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            isOpen = !isOpen;
            for (int i = 0; i < icons.Count; i++)
            {
                if (Notes[i] == null)
                    break;
                icons[i].SetActive(isOpen);
            }
            CloseTouchScreen.SetActive(isOpen);
            ArchiveUI.SetActive(isOpen);
            Core.Description.text = "";
            Core.Note.SetActive(false);
        }
    }
}
