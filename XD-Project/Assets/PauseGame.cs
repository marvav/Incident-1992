using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject[] EscapeMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Escape"))
        {
            if (Time.timeScale == 0)
            {
                ToggleObjects(EscapeMenu, false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                ToggleObjects(EscapeMenu, true);
            }
        }
    }
    void ToggleObjects(GameObject[] objects, bool state)
    {
        foreach (GameObject element in objects)
        {
            element.SetActive(state);
        }
    }
}
