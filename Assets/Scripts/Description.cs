using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public TMP_Text description;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        description.text = text;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        description.text = "";
    }
}
