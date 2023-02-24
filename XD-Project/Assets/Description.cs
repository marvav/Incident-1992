using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class Example : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string text;
    public GameObject description;
    private TMP_Text description_component;
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
