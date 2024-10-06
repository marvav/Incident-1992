using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Core_Utils;
using static Inventory;

public class InventoryMenu : MonoBehaviour
{
    public Core Core;
    public GameObject EscapeMenu;
    public GameObject Settings;
    public GameObject Inventory_Object;
    public GameObject Archive;
    public GameObject[] InventoryExitHideObjects;
    public GameObject[] EscHideObjects;
    public GameObject[] EscShowObjects;
    private List<Vector3> Icon_positions;

    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-860,-370,0), new Vector3(-795,-370,0) , new Vector3(-720,-370,0) ,
                                            new Vector3(-860,-450,0) , new Vector3(-795,-450,0) , new Vector3(-720,-450,0) , new Vector3(-645,-450,0)};
    }


    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            Inventory_Object.SetActive(false);
            if (Time.timeScale == 0) //Turn on
            {
                ToggleEscMenu(false);
                ToggleCursor();
                Time.timeScale = 1;
                //ToggleObjects(InventoryExitHideObjects, false);

            }
            else //Turn off
            {
                //ToggleObjects(EscHideObjects, false);
                ToggleEscMenu(true);
                Time.timeScale = 0;
            }
            Core.DescriptionUI.text = "";
        }
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleEscMenu(false);
            if (Time.timeScale == 0)
            {
                Inventory_Object.SetActive(false);
                ToggleCursor();
                Time.timeScale = 1;
            }
            else
            {
                ToggleOnInventory();
                Time.timeScale = 0;
            }
            Core.DescriptionUI.text = "";
        }
    }
    public void ToggleOnInventory()
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
                else
                    child.SetActive(false);
            }
            else
                child.SetActive(true);
        }
    }

    public void ToggleOffInventory()
    {
        Core.Note.SetActive(false);
        Inventory_Object.SetActive(false);
        foreach(GameObject child in CountChildren(Inventory_Object))
            child.gameObject.SetActive(false);
        foreach (GameObject child in CountChildren(Archive))
            child.gameObject.SetActive(false);
    }

    public void ToggleEscMenu(bool state)
    {
        EscapeMenu.SetActive(state);
        foreach (GameObject child in CountChildren(Settings))
        {
            child.SetActive(false);
        }
    }
}

