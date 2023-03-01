using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventoryAPI;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    public Core Core;
    private InventoryAPI.Inventory Inventory;
    private List<Vector3> Icon_positions;
    // Start is called before the first frame update
    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-378,-157,0), new Vector3(-342,-157,0) , new Vector3(-306,-157,0) ,
                                            new Vector3(-378,-195,0) , new Vector3(-342,-195,0) , new Vector3(-306,-195,0) };
        Inventory = Core.Inventory.GetComponent<InventoryItems>().Inventory;
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
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                ToggleOn();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    void ToggleOn()
    {
        Core.Inventory.SetActive(true);
        int index = 0;
        foreach (GameObject child in Core.CountChildren(Core.Inventory))
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
        Core.Inventory.SetActive(false);
        foreach(GameObject child in Core.CountChildren(Core.Inventory))
            child.gameObject.SetActive(false);
    }
}

