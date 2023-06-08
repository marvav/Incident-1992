using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class Door : MonoBehaviour
{
    public Core Core;
    public string text;
    private bool isHidden;

    // Update is called once per frame
    void Start()
    {
        isHidden = true;
    }
    void FixedUpdate()
    {
        if(isHidden && isCloseToPlayer(transform))
        {
            Core.Description.text = text;
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
