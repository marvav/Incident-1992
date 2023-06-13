using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenIcon : MonoBehaviour, IPointerClickHandler
{
    public AudioSource sound;
    public GameObject content;
    public GameObject background;
    private bool isOpen = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            sound.Play();
            isOpen = !isOpen;
            content.SetActive(isOpen);
            background.SetActive(isOpen);
        }
    }
}
