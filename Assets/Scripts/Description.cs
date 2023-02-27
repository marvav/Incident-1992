using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Consumable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject description;
    public GameObject FlashLight;
    private TMP_Text description_component;
    private FlashLightComponent FlashLightComponent;
    public Button yourButton;
    //Detect if the Cursor starts to pass over the GameObject
    void Start()
    {
        description_component = description.GetComponent<TMP_Text>();
        FlashLightComponent = FlashLight.GetComponent<FlashLightComponent>();
    }

    void TaskOnClick()
    {
        FlashLightComponent.Restore_Capacity();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        description_component.text = text;
        description.SetActive(true);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        description.SetActive(false);
    }
}
