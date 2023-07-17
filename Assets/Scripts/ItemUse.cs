using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Core_Utils;


public class ItemUse : MonoBehaviour, IPointerClickHandler
{
    public GameObject ItemInHand;
    public Core Core;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            Core.PickUpSound.Play();
            if (Inventory.InHand != null && Inventory.InHand.name == ItemInHand.name)
            {
                Inventory.InHand.SetActive(false);
                Inventory.InHand = null;
            }
            else
            {
                if(Inventory.InHand != null)
                    Inventory.InHand.SetActive(false);

                ItemInHand.SetActive(true);
                Inventory.InHand = ItemInHand;
            }
        }
    }
}