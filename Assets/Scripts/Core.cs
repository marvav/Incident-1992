using UnityEngine;
using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;

public class Core : MonoBehaviour
{
    public GameObject Player;
    public GameObject Inventory;
    public GameObject PickUpText;

    public static List<GameObject> CountChildren(GameObject Object)
    {
        List<GameObject> result = new List<GameObject>();
        int index = 0;
        int count = Object.transform.childCount;
        while (index < count)
        {
            result.Add(Object.transform.GetChild(index).gameObject);
            index += 1;
        }
        return result;
    }
    void Start()
    {

    }
}