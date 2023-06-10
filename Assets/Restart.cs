using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using static Core_Utils;

public class Restart : MonoBehaviour, IPointerClickHandler
{
    public Core Core;

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
            ToggleCursor();
        }
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Core.Description.text = "Restart the game";
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Core.Description.text = "";
    }
}
