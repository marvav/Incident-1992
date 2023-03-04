using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Core_Utils;
using static Inventory;

public class InventoryMenu : MonoBehaviour
{
    public GameObject Inventory_Object;
    private List<Vector3> Icon_positions;
    // Start is called before the first frame update
    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-923,-429,0), new Vector3(-852,-429,0) , new Vector3(-781,-429,0) ,
                                            new Vector3(-923,-500,0) , new Vector3(-852,-500,0) , new Vector3(-781,-500,0) };
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("Inventory"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                ToggleOff();
                ToggleCursor();
            }
            else
            {
                Time.timeScale = 0;
                ToggleOn();
                ToggleCursor();
            }
        }
    }
    void ToggleOn()
    {
        Inventory_Object.SetActive(true);
        int index = 0;
        foreach (GameObject child in CountChildren(Inventory_Object))
        {
            if(child.tag == "Icon")
            {
                Item item = Inventory.Find_by_name(child.name);
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
        foreach(GameObject child in CountChildren(Inventory_Object))
            child.gameObject.SetActive(false);
    }
}

