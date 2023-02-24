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
    private List<Vector3> Icon_positions;
    // Start is called before the first frame update
    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-435, 180, 0), new Vector3(-315, 180, 0) };
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
        int index = 0;
        foreach (GameObject element in objects)
        {
            if(element.tag == "Icon")
            {
                InventoryAPI.Item item = Inventory.Find_by_name(element.name);
                if (item!=null)
                {
                    element.SetActive(true);
                    TMP_Text Count;
                    if (element.name == "Battery") //You can have more batteries, so there is the count
                    {
                        Count = element.transform.GetChild(0).GetComponent<TMP_Text>();
                        Count.text = item.count.ToString();
                    }

                    RectTransform element_pos = element.GetComponent<RectTransform>();
                    element_pos.anchoredPosition = Icon_positions[index];
                    index++;
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

