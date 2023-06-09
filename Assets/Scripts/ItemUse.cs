using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class ItemUse : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject ItemInHand;
    public Core Core;
    private bool isHidden;

    void Start() { 
        isHidden = true; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            if (isHidden && Inventory.InHand!="")
            {
                Core.Description.text = "I can't hold more items at once";
            }
            else
            {
                ItemInHand.SetActive(isHidden);
                if(isHidden)
                    Inventory.InHand = gameObject.name;
                else
                    Inventory.InHand = "";
                isHidden = !isHidden;
                Core.Description.text = "";
            }
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