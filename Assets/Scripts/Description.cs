using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Description : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject description;
    private TMP_Text description_component;
    public Button yourButton;
    //Detect if the Cursor starts to pass over the GameObject
    void Start()
    {
        description_component = description.GetComponent<TMP_Text>();
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
