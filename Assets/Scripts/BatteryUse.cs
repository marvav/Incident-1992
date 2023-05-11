using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using static Inventory;


public class Consumable : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text Description;
    public FlashLightComponent FlashLight;
    //Detect if the Cursor starts to pass over the GameObject
    void Start()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
        {
            FlashLight.Restore_Capacity();
            Inventory.Remove("Battery");
            this.gameObject.SetActive(false);
            Description.text = "";
        }
    }
}
