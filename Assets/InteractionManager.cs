using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;
using static Inventory;

public class InteractionManager : MonoBehaviour
{
    public Core Core;
    public GameObject HoldPickable;
    public GrabbingController grabbingController;
    public float InteractionDistance = 2.0f;
    private bool IconHidden = true;
    private RaycastHit coverHit;
    private bool CanPickup = false;
    private bool isClicked = false;
    private GameObject currentIcon;

    void Start()
    {
        currentIcon = Core.PickUpItem;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CastRayHand(InteractionDistance, out coverHit))
        {
            Debug.Log(coverHit.collider.gameObject.name);
            CanPickup = false;
            switch (coverHit.collider.gameObject.layer)
            {
                case 7:
                    {
                        if (!grabbingController.isHolding())
                        {
                            CanPickup = true;
                            SwapIcons(HoldPickable);
                            currentIcon.SetActive(true);
                            IconHidden = false;
                        }
                        else
                        {
                            currentIcon.SetActive(false);
                            IconHidden = true;
                        }
                        return;
                    }
                case 12:
                    {
                        SwapIcons(Core.PickUpItem);
                        currentIcon.SetActive(true);
                        IconHidden = false;
                        if (Input.GetButton("Pick Up"))
                        {
                            currentIcon.SetActive(false);
                            if (coverHit.collider.gameObject.tag == "Inventory")
                                coverHit.collider.gameObject.GetComponent<PickUpItem>().PutItemInInventory();

                            if (coverHit.collider.gameObject.tag == "ReadableNote")
                                coverHit.collider.gameObject.GetComponent<ReadableNote>().PickUpNote();
                        }
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (coverHit.collider.gameObject.tag == "Toggle")
                            {
                                coverHit.collider.gameObject.GetComponent<ToggleObject>().Toggle();
                            }
                        }
                        return;
                    }
                case 13:
                    {
                        SwapIcons(Core.Click);
                        currentIcon.SetActive(true);
                        IconHidden = false;
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (!isClicked)
                            {
                                currentIcon.SetActive(false);
                                isClicked = true;
                                if (coverHit.collider.gameObject.tag == "Toggle")
                                    coverHit.collider.gameObject.GetComponent<ToggleObject>().Toggle();
                            }
                        }
                        else
                            isClicked = false;
                        return;
                    }
            }
        }
        else
        {
            isClicked = false;
            if (!IconHidden)
            {
                currentIcon.SetActive(false);
                IconHidden = true;
            }
        }
    }

    void SwapIcons(GameObject icon)
    {
        currentIcon.SetActive(false);
        currentIcon = icon;
    }

    public GameObject CanPickUp()
    {
        Debug.Log(CanPickup);
        return CanPickup ? coverHit.collider.gameObject : null;
    }
}
