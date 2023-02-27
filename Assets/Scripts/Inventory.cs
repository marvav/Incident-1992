using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryAPI;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    public GameObject Inventory_Object;
    private InventoryAPI.Inventory Inventory;
    private List<Vector3> Icon_positions;
    // Start is called before the first frame update
    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-370,-180,0), new Vector3(-620, -325, 0) , new Vector3(-565, -325, 0) ,
                                            new Vector3(-675, -380, 0) , new Vector3(-620, -380, 0) , new Vector3(-565, -380, 0) };
        Inventory = Inventory_Object.GetComponent<InventoryItems>().Inventory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (Time.timeScale == 0)
            {
                ToggleOff();
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                ToggleOn();
            }
        }
    }
    void ToggleOn()
    {
        Inventory_Object.SetActive(true);
        int index = 0;
        foreach (GameObject child in CountChildren())
        {
            if(child.tag == "Icon")
            {
                InventoryAPI.Item item = Inventory.Find_by_name(child.name);
                if (item!=null)
                {
                    child.SetActive(true);
                    TMP_Text Count;
                    if (child.name == "Battery") //You can have more batteries, so there is the count
                    {
                        Count = child.transform.GetChild(0).GetComponent<TMP_Text>();
                        Count.text = item.count.ToString();
                    }

                    RectTransform element_pos = child.GetComponent<RectTransform>();
                    element_pos.anchoredPosition = Icon_positions[index];
                    index++;
                }
            }
            else
                child.SetActive(true);
        }
    }

    void ToggleOff()
    {
        Inventory_Object.SetActive(false);
        foreach(GameObject child in CountChildren())
            child.gameObject.SetActive(false);
    }

    List<GameObject> CountChildren()
    {
        List<GameObject> result = new List<GameObject>();
        int index = 0;
        int count = Inventory_Object.transform.childCount;
        while (index < count)
        {
            result.Add(Inventory_Object.transform.GetChild(index).gameObject);
            index += 1;
        }
        return result;
    }
}

