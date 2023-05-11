using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Archive;


public class ArchiveRead : MonoBehaviour, IPointerClickHandler
{
    public GameObject Description;
    public GameObject ArchiveUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Debug.Log("Archive opened");
            ArchiveUI.SetActive(true);
            Description.SetActive(false);
        }
    }
}
