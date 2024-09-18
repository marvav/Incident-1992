using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Core_Utils;

public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverGain = 0.05f;
    public bool isText = true;
    private RectTransform transform;
    private TMP_Text text;
    private float scale;

    void Start()
    {
        transform = GetComponent<RectTransform>();
        scale = transform.localScale.x;
        if (isText)
            text = GetComponent<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (isText)
            text.fontStyle = (FontStyles)FontStyle.Bold;
        else
            transform.localScale = new Vector3(transform.localScale.x + hoverGain, transform.localScale.y + hoverGain, transform.localScale.z + hoverGain);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (isText)
            text.fontStyle = (FontStyles)FontStyle.Normal;
        else
            transform.localScale = new Vector3(scale, scale, scale);
    }
}
