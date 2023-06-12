using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using static Core_Utils;


public class ShowControls : MonoBehaviour, IPointerClickHandler
{
    public AudioSource sound;
    private List<GameObject> controls;
    private bool isOpen = false;

    public void Start()
    {
        controls = CountChildren(this.gameObject);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            sound.Play();
            isOpen = !isOpen;

            for (int i = 0; i < controls.Count; i++)
            {
                controls[i].SetActive(isOpen);
            }
        }
    }
}
