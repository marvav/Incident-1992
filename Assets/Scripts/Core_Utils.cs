using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Core_Utils
{
    public static GameObject Player = GameObject.Find("Player");
    public static GameObject HoldPoint = GameObject.Find("HoldPoint");
    public static System.Random rand = new System.Random();

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

    public static void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.None)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        Cursor.visible = !Cursor.visible;
    }

    public static bool isCloseToPlayer(Transform current)
    {
        return Vector3.Distance(current.position, Player.transform.position) < 2;
    }
    public static bool isCloseToPlayer(Transform current, float distance)
    {
        return Vector3.Distance(current.position, Player.transform.position) < distance;

    }
    public static bool CanInteract(Transform current, float distance)
    {
        return Vector3.Distance(current.position, HoldPoint.transform.position) < distance;
            //Physics.Linecast(Player.transform.position, HoldPoint.transform.position);
    }
}
