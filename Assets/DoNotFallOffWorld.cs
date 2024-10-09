using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotFallOffWorld : MonoBehaviour
{
    public Core Core;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && Core.GrabbingController.GetHeldObject() == this.gameObject)
        {
            Debug.Log("Drop");
            Core.GrabbingController.DropObject();
        }
    }
}
