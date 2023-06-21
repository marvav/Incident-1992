using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Description3D : MonoBehaviour
{
    public Core Core;
    public string text;
    public float range = 2.0f;
    public float angle = 90.0f;
    public int clueID = 0;
    private bool isHidden = true;

    void Update()
    {
        if (CanInteract(this.gameObject, range, angle))
        {
            if (isHidden)
            {
                Core.Description.text = text;
                isHidden = false;
                Core.ProgressManager.changeObjective(clueID);
            }
        }
        else
        {
            if (!isHidden)
            {
                isHidden = true;
                Core.Description.text = "";
            }
        }
    }
}
