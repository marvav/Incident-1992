using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Core_Utils
{
    public static GameObject Player = GameObject.Find("Player");

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

    public static bool isCloseToPlayer(Transform current, GameObject player)
    {
        return Vector3.Distance(current.position + new Vector3(0, 2, 0), player.transform.position) < 1.5f
                || Vector3.Distance(current.position, player.transform.position) < 1.5f;
    }
}
