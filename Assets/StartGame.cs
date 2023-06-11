using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core_Utils;

public class StartGame : MonoBehaviour, IPointerClickHandler
{
    public GameObject OpeningScene;
    public GameObject Menu;
    void Start()
    {
        Time.timeScale = 0;
        ToggleCursor();
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
