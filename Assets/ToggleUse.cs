using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ToggleUse : MonoBehaviour
{
    public Core Core;
    public GameObject state1;
    public GameObject state2;
    public float range;
    private bool isHidden = true;
    private bool state = false;
    private bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        if(isCloseToPlayer(transform, range))
        {
            isHidden = false;
            Core.PickUpItem.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                if (!isClicked)
                {
                    isClicked = true;
                    state1.SetActive(state);
                    state2.SetActive(!state);
                    state = !state;
                }
            }
            else
                isClicked = false;
        }
        else
        {
            isClicked = false;
            if (!isHidden)
            {
                Core.PickUpItem.SetActive(false);
                isHidden = true;
            }
        }
    }
}
