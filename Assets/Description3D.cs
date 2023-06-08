using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Description3D : MonoBehaviour
{
    public Core Core;
    public string text;
    public int objectiveID;
    public string objective;
    private bool isHidden;

    // Update is called once per frame
    void Start()
    {
        isHidden = true;
    }
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            if (isHidden)
            {
                Core.Description.text = text;
                isHidden = false;
                Core.ProgressManager.changeObjective(objectiveID, objective);
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
