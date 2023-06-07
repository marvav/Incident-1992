using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using static Core_Utils;

public class LostFlashlight : MonoBehaviour
{
    public Core Core;
    public int id;
    public string objective;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            Core.Description.text = "This is... weird?!";
            Core.ProgressManager.changeObjective(id, objective);

        }
    }
}
