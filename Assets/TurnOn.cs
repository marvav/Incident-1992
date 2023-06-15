using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class TurnOn : MonoBehaviour
{
    public Core Core;
    public AudioClip sound;
    public GameObject objToTurnOff;
    public GameObject obj;
    public float range = 2;
    public bool isOn = false;
    private bool isHidden = true;
    private bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        if (isCloseToPlayer(transform, range))
        {
            isHidden = false;
            Core.Click.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                if (!isClicked)
                {
                    if (objToTurnOff != null)
                    {
                        objToTurnOff.SetActive(false);
                    }
                    Core.Click.SetActive(false);
                    isOn = !isOn;
                    isClicked = true;
                    obj.SetActive(isOn);
                    Core.GeneralAudio.clip = sound;
                    Core.GeneralAudio.Play();
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
                Core.Click.SetActive(false);
                isHidden = true;
            }
        }
    }
}
