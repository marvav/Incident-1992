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
            if (isHidden && Inventory.InHand!="")
            {
                Core.Description.text = "I can't hold more items at once";
            }
            else
            {
                ItemInHand.SetActive(isHidden);
                if (isHidden)
                {
                    Inventory.InHand = gameObject.name;
                    Core.Inventory.SetActive(false);
                    Time.timeScale = 1;
                    ToggleCursor();
                }
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