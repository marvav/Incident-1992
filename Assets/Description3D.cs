using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Description3D : MonoBehaviour
{
    public Core Core;
    public string[] text;
    public float range = 2.0f;
    public int clueID = 0;
    private bool isHidden = true;

    void Update()
    {
        if (isCloseToPlayer(transform, range))
        {
            if (isHidden)
            {
                Core.Description.text = text[Core.GetLanguage()];
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
