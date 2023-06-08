using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject walkieTalkie;
    public Core Core;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Core.Description.text = "";
            if(walkieTalkie.activeSelf)
                walkieTalkie.SetActive(false);
            else
                walkieTalkie.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = text;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.Description.text = "";
    }
}
