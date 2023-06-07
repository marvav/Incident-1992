using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class ItemUse : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public Core Core;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Inventory.InHand = this.name;
            Core.Description.text = "";
            Core.ItemInHand.SetActive(true);
            Image inHand_icon = Core.ItemInHand.GetComponent<Image>();
            Image item_icon = this.GetComponent<Image>();
            inHand_icon.sprite = item_icon.sprite;
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