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
        //if (pause.isPaused)
        //     return;
        if (Input.GetMouseButtonDown(1) && heldObject != null)
        {
            Vector3 moveDirection = (holdPoint.position - transform.position).normalized;
            heldObjectRb.AddForce(moveDirection * 400);
            DropObject();
        }
        if (Input.GetMouseButtonDown(0) && SomethingToHoldIcon.activeSelf)
        {
            if (heldObject == null)
                PickupObject(Hand.CanPickUp());
            else
                DropObject();
        }
        if (heldObject != null)
        {
            MoveObject();
        }
    }

    //void MoveHoldPoint()
    //{
    //    move += Input.mouseScrollDelta.y / 10;
    //    move = Mathf.Clamp(move, 1f, 4f);
    //    holdPoint.localPosition = new Vector3(0,0, move);
    //    Debug.Log(move);
    //}

    public void MoveObject()
    {
        //if (heldObject.GetComponent<GrabbedObject>().collideWithPlayer)
        //{
        //    DropObject();
        //    return;
        //}
        //MoveHoldPoint();
        if (Vector3.Distance(heldObject.transform.position, holdPoint.position) > 0.01f)
        {
            Vector3 moveDirection = (holdPoint.position - heldObject.transform.position);
            heldObjectRb.AddForce(moveDirection * pickupForce);
        }
        else if (!wasCentered)
        {
            Debug.Log("Sentered");
            wasCentered = true;
        }
        if (((Vector3.Distance(heldObject.transform.position, holdPoint.position) > holdRange) && wasCentered) || Vector3.Distance(heldObjectRb.transform.position, holdPoint.position) > 1)
        {
            Debug.Log("Too far");
            DropObject();
        }
    }

    public void PickupObject(GameObject pickObj)
    {
        if (pickObj == null)
            return;
        if (pickObj.GetComponent<Rigidbody>())
        {
            Debug.Log("Rigid");
            holdPoint.rotation = orientation.rotation;
            holdPoint.position = pickObj.transform.position;   ////////////// comment to make the game cooler
            heldObjectRb = pickObj.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.drag = 10;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjectRb.transform.parent = holdPoint;
            //heldObjectRb.transform.parent = transform;
            heldObject = pickObj;
            //holdPoint.localPosition = new Vector3(0, 0, heldObject.transform.localScale.x * 2);
        }
    }

    //void RotateObject()
    //{
    //    //rotation += new Vector3(0, 0, Time.deltaTime * 10);
    //    //heldObject.transform.rotation = Quaternion.Euler(rotation);
    //    if(Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        mode++;
    //        if (mode == 2)
    //            mode = 0;
    //    }
    //    rotationSpeed = rotationSpeedMax;
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        rotationSpeed = rotationSpeedMax / 10;
    //    }
    //    switch (mode)
    //    {
    //        case 0:
    //            if (Input.GetKey(KeyCode.Q))
    //                heldObject.transform.Rotate(heldObject.transform.up, rotationSpeed, Space.World);
    //            if (Input.GetKey(KeyCode.E))
    //                heldObject.transform.Rotate(heldObject.transform.up, -rotationSpeed, Space.World);
    //            break;
    //        case 1:
    //            if (Input.GetKey(KeyCode.Q))
    //                heldObject.transform.Rotate(heldObject.transform.right, rotationSpeed, Space.World);
    //            if (Input.GetKey(KeyCode.E))
    //                heldObject.transform.Rotate(heldObject.transform.right, -rotationSpeed, Space.World);
    //            break;
    //    }
    //}
    public void DropObject()
    {
        Debug.Log("Drop");
        heldObjectRb.useGravity = true;
        heldObjectRb.drag = 1;
        heldObjectRb.constraints = RigidbodyConstraints.None;
        heldObjectRb.transform.parent = null;
        heldObject = null;
        wasCentered = false;
        //holdPointRotator.enabled = false;
        //holdPointRotator.Reset();
    }
}