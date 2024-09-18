using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingController : MonoBehaviour
{
    [SerializeField] Transform holdPoint;
    public InteractionManager Hand;
    public GameObject SomethingToHoldIcon;
    public Transform orientation;
    private GameObject heldObject = null;
    private Rigidbody heldObjectRb;
    private bool wasCentered = false;
    public LayerMask pickableLayer;
    [SerializeField] private float holdRange = 5f;
    [SerializeField] private float pickupForce = 100f;
    [SerializeField] Vector3 rotation;
    private ObjectRotator holdPointRotator;
    // [SerializeField] private Pause pause;

    public GameObject GetHeldObject() { return heldObject; }

    public bool isHolding()
    {
        return heldObject != null;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1) && heldObject != null)
        {
            Vector3 moveDirection = (holdPoint.position - transform.position).normalized;
            heldObjectRb.AddForce(moveDirection * 400);
            DropObject();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                if (SomethingToHoldIcon.activeSelf)
                    PickupObject(Hand.CanPickUp());
            }
            else
                DropObject();
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }

    public void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdPoint.position) > 0.01f)
        {
            Vector3 moveDirection = (holdPoint.position - heldObject.transform.position);
            heldObjectRb.AddForce(moveDirection * pickupForce);
        }
        else if (!wasCentered)
        {
            //Debug.Log("Sentered");
            wasCentered = true;
        }
        if (((Vector3.Distance(heldObject.transform.position, holdPoint.position) > holdRange) && wasCentered) || Vector3.Distance(heldObjectRb.transform.position, holdPoint.position) > 1)
        {
            //Debug.Log("Too far");
            DropObject();
        }
    }

    public void PickupObject(GameObject pickObj)
    {
        if (pickObj == null)
            return;
        if (pickObj.GetComponent<Rigidbody>())
        {
            //Debug.Log("Rigid");
            holdPoint.rotation = orientation.rotation;
            holdPoint.position = pickObj.transform.position;
            heldObjectRb = pickObj.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.drag = 10;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjectRb.transform.parent = holdPoint;
            heldObject = pickObj;
        }
    }

    public void DropObject()
    {
        //Debug.Log("Drop");
        heldObjectRb.useGravity = true;
        heldObjectRb.drag = 1;
        heldObjectRb.constraints = RigidbodyConstraints.None;
        heldObjectRb.transform.parent = null;
        heldObject = null;
        wasCentered = false;
    }
}