using UnityEngine;
using System.Collections;

public class BreakDoorOpen : MonoBehaviour
{
    public int DestructiveLayer;
    public GameObject ObjectToMove;
    public GameObject MovedObject;
    public Core Core;
    public int clueID;

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.layer == DestructiveLayer || this.gameObject.layer == DestructiveLayer) && collision.relativeVelocity.magnitude > 0.2)
        {
            MovedObject.SetActive(true);
            ObjectToMove.SetActive(false);
            Core.ProgressManager.changeObjective(clueID);
        }
    }
}
