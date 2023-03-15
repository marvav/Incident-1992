using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class ItemUse : MonoBehaviour, IPointerClickHandler
{
    public GameObject Description;
    public GameObject ItemInHand;

    //Detect if the Cursor starts to pass over the GameObject
    void Start()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Debug.Log("Item in hand");
            Inventory.InHand = this.name;
            Description.SetActive(false);
            ItemInHand.SetActive(true);
            Image inHand_icon = ItemInHand.GetComponent<Image>();
            Image item_icon = this.GetComponent<Image>();
            inHand_icon.sprite = item_icon.sprite;
        }
    }
}