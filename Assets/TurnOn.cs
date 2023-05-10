using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class TurnOn : MonoBehaviour
{
    public Core Core;
    public GameObject Lamp;
    public GameObject LightUp;
    public GameObject LightOff;
    private GameObject currentIcon;
    private bool isHidden;
    private bool isOn;
    private bool isReleased;
    // Start is called before the first frame update
    void Start()
    {
        currentIcon = LightUp;
        isHidden = true;
        isReleased = true;
        isOn = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform, Core.Player))
        {
            isHidden = false;
            currentIcon.SetActive(true);
            if (isReleased && Input.GetButton("Pick Up"))
            {
                currentIcon.SetActive(false);
                if (!isOn)
                {
                    Lamp.SetActive(true);
                    currentIcon = LightOff;
                    isOn = true;
                }
                else
                {
                    isOn = false;
                    Lamp.SetActive(false);
                    currentIcon = LightUp;
                }
                isReleased = false;
            }
        }
        else
        {
            if (!isHidden)
            {
                currentIcon.SetActive(false);
                isHidden = true;
                isReleased = true;
            }
        }
    }
}
