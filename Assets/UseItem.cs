using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class UseItem : MonoBehaviour
{
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public GameObject NeededItem;
    public string message;
    public AudioSource sound;
    public Core Core;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCloseToPlayer(transform))
        {
            Core.Description.text = message;
            Debug.Log(NeededItem.activeSelf);
            if (NeededItem.activeSelf && Input.GetMouseButtonDown(0))
            {
                Core.Description.text = "";
                sound.Play();
                MovedObject.SetActive(true);
                ObjectToMove.SetActive(false);
            }
        }
        else
        {
            Core.Description.text = "";
        }
    }
}
