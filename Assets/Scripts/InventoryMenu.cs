using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Core_Utils;
using static Inventory;

public class InventoryMenu : MonoBehaviour
{
    public GameObject EscapeMenu;
    public GameObject Inventory_Object;
    public GameObject Archive;
    public GameObject Note;
    private List<Vector3> Icon_positions;
    // Start is called before the first frame update
    void Start()
    {
        Icon_positions = new List<Vector3> {new Vector3(-910,-420,0), new Vector3(-840,-420,0) , new Vector3(-770,-420,0) ,
                                            new Vector3(-910,-490,0) , new Vector3(-840,-490,0) , new Vector3(-770,-490,0) };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                EscapeMenu.SetActive(false);
                ToggleOff();
                ToggleCursor();

            }
            else
            {
                ToggleOff();
                EscapeMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetButtonDown("Inventory"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                EscapeMenu.SetActive(false);
                ToggleOff();
                ToggleCursor();
            }
            else
            {
                EscapeMenu.SetActive(false);
                ToggleOn();
                Time.timeScale = 0;
            }
        }
    }
    public void ToggleOn()
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

    public void ToggleOff()
    {
        Note.SetActive(false);
        Inventory_Object.SetActive(false);
        foreach(GameObject child in CountChildren(Inventory_Object))
            child.gameObject.SetActive(false);
        foreach (GameObject child in CountChildren(Archive))
            child.gameObject.SetActive(false);
    }
}

