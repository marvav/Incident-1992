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
    private List<GameObject> icons;
    private bool isOpen;

    public void Start()
    {
        icons = CountChildren(ArchiveUI);
        isOpen = false;
    }
    public void Update()
    {
        if(isOpen && Input.GetButton("Pick Up"))
        {
            ArchiveUI.SetActive(false);
            Core.Description.text = "";
            Core.Note.SetActive(false);
            isOpen = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            for(int i = 0; i<icons.Count;i++)
            {
                if (Notes[i] == null)
                    break;
                icons[i].SetActive(true);
            }
            ArchiveUI.SetActive(true);
            Core.Description.text = "";
            Core.Note.SetActive(false);
            isOpen = true;
        }
    }
}
