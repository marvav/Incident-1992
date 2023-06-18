using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;
using static Core_Utils;


public class ItemUse : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject ItemInHand;
    public Core Core;
    private bool isHidden = true;

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
                Core.Inventory.SetActive(false);
                Time.timeScale = 1;
                ToggleCursor();
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