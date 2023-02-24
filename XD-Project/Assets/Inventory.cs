using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryAPI;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    public GameObject[] InventoryUI;
    public GameObject Inventory_Object;
    private InventoryAPI.Inventory Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = Inventory_Object.GetComponent<InventoryItems>().Inventory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (Time.timeScale == 0)
            {
                ToggleOff(InventoryUI);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                ToggleOn(InventoryUI);
            }
        }
    }
    void ToggleOn(GameObject[] objects)
    {
        Inventory_Object.SetActive(true);

        foreach (GameObject element in objects)
        {
            if(element.tag == "Icon")
            {
                InventoryAPI.Item item = Inventory.Find_by_name(element.name);
                if (item!=null)
                {
                    element.SetActive(true);
                    TMP_Text Count;
                    Count = element.transform.GetChild(0).GetComponent<TMP_Text>();
                    Count.text = item.count.ToString();
                }
            }
            else
                element.SetActive(true);
        }
    }

    void ToggleOff(GameObject[] objects)
    {
        Inventory_Object.SetActive(false);
        foreach (GameObject element in objects)
        {
            element.SetActive(false);
        }
    }
}

