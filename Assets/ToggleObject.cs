using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class ToggleObject : MonoBehaviour
{
    public Core Core;
    public AudioClip sound;
    public GameObject obj;
    public GameObject objToSwap;
    public float range = 2;
    public bool isOn = false;
    public Renderer renderer;
    private bool isHidden = true;
    private bool isClicked = false;

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible && CanInteract(this.gameObject, range))
        {
            isHidden = false;
            Core.Click.SetActive(true);
            if (Input.GetButton("Pick Up"))
            {
                if (!isClicked)
                {
                    Core.Click.SetActive(false);
                    isOn = !isOn;
                    isClicked = true;
                    obj.SetActive(isOn);
                    if(objToSwap!=null)
                        objToSwap.SetActive(!isOn);
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
