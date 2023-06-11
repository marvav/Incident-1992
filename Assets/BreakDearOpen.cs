using UnityEngine;
using System.Collections;

public class BreakDoorOpen : MonoBehaviour
{
    public int DestructiveLayer;
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public Core Core;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == DestructiveLayer && collision.relativeVelocity.magnitude > 0.2)
        {
            MovedObject.SetActive(true);
            Core.Description.text = "";
            ObjectToMove.SetActive(false);
        }
    }
}
