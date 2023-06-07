using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class LostFlashlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Core Core;
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = "Something must have happened here";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.Description.text = "";
    }
}
