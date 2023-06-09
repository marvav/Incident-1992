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
            if (isHidden && Inventory.InHand)
            {
                Core.Description.text = "I can't hold more items at once";
            }
            else
            {
                ItemInHand.SetActive(isHidden);
                Inventory.InHand = !Inventory.InHand;
                isHidden = !isHidden;
                Core.Description.text = "";
            }

            //Inventory.InHand = this.name;
            //Core.Description.text = "";
            //ItemInHand.SetActive(true);
            //Image inHand_icon = Core.ItemInHand.GetComponent<Image>();
            //Image item_icon = this.GetComponent<Image>();
            //inHand_icon.sprite = item_icon.sprite;
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