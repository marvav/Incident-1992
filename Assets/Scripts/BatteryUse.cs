using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class Consumable : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Description;
    public InventoryMenu InventoryMenu;
    public AudioSource sound;
    public FlashLightComponent FlashLight;
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            FlashLight.Restore_Capacity();
            Inventory.Remove("Battery");
            Description.text = "";
            sound.Play();
            InventoryMenu.ToggleOnInventory();
        }
    }
}
