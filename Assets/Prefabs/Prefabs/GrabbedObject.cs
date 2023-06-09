using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class GrabbedObject : MonoBehaviour
{
    public GameObject HoldIcon;
    public GrabbingController GrabbingController;
    public bool collideWithPlayer=false;
    private bool isHidden;
    void Start()
    {
        isHidden = true;
    }

    void FixedUpdate()
    {
        if (!GrabbingController.isHolding() && isCloseToPlayer(transform))
        {
            isHidden = false;
            HoldIcon.SetActive(true);
        }
        else
        {
            if(!isHidden)
            {
                HoldIcon.SetActive(false);
                isHidden = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {
            collideWithPlayer = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collideWithPlayer = false;
        }
    }
}
