using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Consumable : MonoBehaviour
{
    public GameObject FlashLight;
    private FlashLightComponent FlashLightComponent;
    public Button yourButton;
    //Detect if the Cursor starts to pass over the GameObject
    void Start()
    {
        FlashLightComponent = FlashLight.GetComponent<FlashLightComponent>();
    }

    void TaskOnClick()
    {
        FlashLightComponent.Restore_Capacity();
    }
}
