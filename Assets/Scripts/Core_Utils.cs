using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Core_Utils
{
    public static GameObject Player;
    public static GameObject Hand;
    public static GameObject Camera;
    public static System.Random rand = new System.Random();
    public static int interactionMask = ~(1 << 8);
    public static int pickableMask = (1 << 7);

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

    public static void ToggleObjects(GameObject[] objects, bool state)
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(state);
        }
    }

    public static void ToggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.None)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;

        Cursor.visible = !Cursor.visible;
    }

    public static bool isCloseToPlayer(Transform current, float distance)
    {
        return Vector3.Distance(current.position, Hand.transform.position) < distance;
    }


    public static bool CanInteract(GameObject current, float distance, float angle)
    {
        if(isCloseToPlayer(current.transform, distance))
        {
            RaycastHit coverHit;
            Vector3 direction = (current.transform.position - Camera.transform.position).normalized;
            Vector3 directionHold = (Hand.transform.position - Camera.transform.position).normalized;
            //Debug.DrawRay(Camera.transform.position, directionHold, Color.green);
            //Debug.DrawRay(Camera.transform.position, direction, Color.green);
            //Debug.Log(Vector3.Angle(direction, directionHold));
            if (Vector3.Angle(direction, directionHold) <= angle && Physics.Raycast(Camera.transform.position, direction, out coverHit, distance, interactionMask))
            {
                //Debug.Log(coverHit.collider.gameObject.name);
                return coverHit.collider.gameObject.name == current.name;
            }
        }
        return false;
    }

    public static bool CanPickUp(GameObject current, float distance, float angle, RaycastHit coverHit)
    {
        if (isCloseToPlayer(current.transform, distance))
        {
            Vector3 direction = (current.transform.position - Camera.transform.position).normalized;
            Vector3 directionHold = (Hand.transform.position - Camera.transform.position).normalized;
            //Debug.DrawRay(Camera.transform.position, directionHold, Color.green);
            //Debug.DrawRay(Camera.transform.position, direction, Color.green);
            //Debug.Log(Vector3.Angle(direction, directionHold));
            return Vector3.Angle(direction, directionHold) <= angle && Physics.Raycast(Camera.transform.position, direction, out coverHit, distance, pickableMask);
        }
        return false;
    }

    public static bool CastRayHand(float distance, out RaycastHit coverHit)
    {
        Vector3 direction = (Hand.transform.position - Camera.transform.position).normalized;
        return Physics.Raycast(Camera.transform.position, direction, out coverHit, distance);
    }
}
