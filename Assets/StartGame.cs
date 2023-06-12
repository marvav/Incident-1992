using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core_Utils;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
    public GameObject OpeningScene;
    public GameObject Menu;
    void FixedUpdate()
    {
        if(Cursor.lockState!= CursorLockMode.None)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 1)
        {
            OpeningScene.SetActive(true);
            Time.timeScale = 1;
            ToggleCursor();
            Menu.SetActive(false);
        }
    }
}
