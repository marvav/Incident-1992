using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseIcon : MonoBehaviour, IPointerClickHandler
{
    public AudioSource sound;
    public GameObject content;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            sound.Play();
            content.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
