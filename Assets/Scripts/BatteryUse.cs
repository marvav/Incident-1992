using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class Consumable : MonoBehaviour, IPointerClickHandler
{
    public Core Core;
    public InventoryMenu InventoryMenu;
    public FlashLightComponent FlashLight;
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            FlashLight.Restore_Capacity();
            Inventory.Remove("Battery");
            Core.Description.text = "";
            Core.PickUpSound.Play();
            if(Inventory.Find_by_name("Battery")==null)
                this.gameObject.SetActive(false);
            InventoryMenu.ToggleOnInventory();

        }
    }
}
