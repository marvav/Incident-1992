using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GameObject[] Inventory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (Time.timeScale == 0)
            {
                ToggleObjects(Inventory, false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                ToggleObjects(Inventory, true);
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

