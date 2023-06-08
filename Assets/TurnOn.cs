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
    // Start is called before the first frame update
    void Start()
    {
        isHidden = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            isHidden = false;
            Core.Click.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                Lamp.enabled = !Lamp.enabled;
                sound.Play();
            }
        }
        else
        {
            if (!isHidden)
            {
                Core.Click.SetActive(false);
                isHidden = true;
            }
        }
    }
}
