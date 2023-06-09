using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class TurnOn : MonoBehaviour
{
    public Core Core;
    public AudioSource sound;
    public Light Lamp;
    private bool isHidden;
    private bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;
        isClicked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            isHidden = false;
            Core.Click.SetActive(true);
            if (isClicked)
            {
                return;
            }
            if (Input.GetButton("Pick Up"))
            {
                isClicked = true;
                Lamp.enabled = !Lamp.enabled;
                sound.Play();
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
