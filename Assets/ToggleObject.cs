using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ToggleObject : MonoBehaviour
{
    public Core Core;
    public AudioClip sound;
    public GameObject OptionalCustomIcon;
    public GameObject[] objects;
    public GameObject[] objectsToSwap;
    public bool isOn = false;
    private bool isHidden = true;
    private bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        if (CanInteract(this.gameObject, 1.0f, 35.0f))
        {
            isHidden = false;
            if(OptionalCustomIcon == null)
                Core.Click.SetActive(true);
            else
                OptionalCustomIcon.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                if (!isClicked)
                {
                    Core.Click.SetActive(false);
                    isOn = !isOn;
                    isClicked = true;
                    ToggleObjects(objects, isOn);
                    ToggleObjects(objectsToSwap, !isOn);
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
                if (OptionalCustomIcon == null)
                    Core.Click.SetActive(false);
                else
                    OptionalCustomIcon.SetActive(false);
                isHidden = true;
            }
        }
    }
}
