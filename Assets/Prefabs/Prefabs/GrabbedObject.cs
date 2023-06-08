using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class GrabbedObject : MonoBehaviour
{
    public GameObject HoldIcon;
    public GrabbingController GrabbingController;
    public bool collideWithPlayer=false;
    void FixedUpdate()
    {
        if (!GrabbingController.isHolding() && isCloseToPlayer(transform))
            HoldIcon.SetActive(true);
        else
            HoldIcon.SetActive(false);
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
