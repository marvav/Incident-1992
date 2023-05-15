using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using static Core_Utils;


public class ShowControls : MonoBehaviour, IPointerClickHandler
{
    private List<GameObject> controls;
    private bool isOpen;

    public void Start()
    {
        controls = CountChildren(this.gameObject);
        isOpen = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            Debug.Log("clicked");
            isOpen = !isOpen;

            for (int i = 0; i < controls.Count; i++)
            {
                Debug.Log("child");
                controls[i].SetActive(isOpen);
            }
        }
    }
}
