using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Core Core;
    public string[] text;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = text[Core.GetLanguage()];
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.Description.text = "";
    }
}
