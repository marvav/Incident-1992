using UnityEngine;
using System.Collections;

public class BreakDoorOpen : MonoBehaviour
{
    public int DestructiveLayer;
    public GameObject ObjectToMove;
    private bool Broken;
    void Start()
    {
        Broken = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!Broken && collision.gameObject.layer == DestructiveLayer && collision.relativeVelocity.magnitude > 0.2)
        {
            ObjectToMove.transform.localPosition = new Vector3(0.630999982f, 0, -0.463f);
            ObjectToMove.transform.eulerAngles = new Vector3(ObjectToMove.transform.eulerAngles.x, ObjectToMove.transform.eulerAngles.y, ObjectToMove.transform.eulerAngles.z+105);
            Broken = true;

        }
    }
}
