using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class ItemUse : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Description;
    public GameObject ItemInHand;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Inventory.InHand = this.name;
            Description.text = "";
            ItemInHand.SetActive(true);
            Image inHand_icon = ItemInHand.GetComponent<Image>();
            Image item_icon = this.GetComponent<Image>();
            inHand_icon.sprite = item_icon.sprite;
        }
    }
}