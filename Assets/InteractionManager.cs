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
    private GameObject currentDescription = null;
    private GameObject currentIcon;
    private GameObject lastObject = null;

    void Start()
    {
        currentIcon = Core.PickUpItem;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CanPickup = false;
        if (CastRayHand(InteractionDistance, out coverHit))
        {
            if(lastObject!= coverHit.collider.gameObject)
                leaveObject();

            if (coverHit.collider.gameObject.tag == "Description")
                ShowDescription();
            else
                Core.Description.text = "";

            if (coverHit.collider.gameObject.layer != 7 && coverHit.distance > InteractionDistance / 2)
                return;

            Debug.Log(coverHit.collider.gameObject.name);
            switch (coverHit.collider.gameObject.layer)
            {
                case 7:
                    {
                        if (!grabbingController.isHolding())
                        {
                            CanPickup = true;
                            SwapIcons(HoldPickable);
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
                        ShowDescription();
                        SwapIcons(Core.PickUpItem);
                        if (Input.GetButton("Pick Up"))
                        {
                            currentIcon.SetActive(false);
                            PickUpItem component = coverHit.collider.gameObject.GetComponent<PickUpItem>();
                            if (component != null)
                                component.PutItemInInventory();
                            else
                                coverHit.collider.gameObject.GetComponent<ReadableNote>().PickUpNote();
                        }
                        return;
                    }
                case 13:
                    {
                        ShowDescription();
                        ToggleObject toggle = coverHit.collider.gameObject.GetComponent<ToggleObject>();
                        InteractionTeleport teleport = null;
                        if (toggle == null)
                        {
                            teleport = coverHit.collider.gameObject.GetComponent<InteractionTeleport>();
                            SwapIcons(teleport.icon);
                        }
                        else
                            SwapIcons(toggle.icon);

                        if (Input.GetMouseButtonDown(0))
                        {
                            if (!isClicked)
                            {
                                currentIcon.SetActive(false);
                                isClicked = true;
                                if (toggle != null)
                                    toggle.Toggle();
                                else
                                    teleport.Teleport();

                            }
                        }
                        else
                            isClicked = false;
                        return;
                    }
                default:
                    {
                        leaveObject();
                        return;
                    }
            }
        }
        else
            leaveObject();
    }

    void SwapIcons(GameObject icon)
    {
        if(icon != null)
        {
            currentIcon.SetActive(false);
            currentIcon = icon;
            currentIcon.SetActive(true);
            IconHidden = false;
        }
    }

    public GameObject CanPickUp()
    {
        //Debug.Log(CanPickup);
        return CanPickup ? coverHit.collider.gameObject : null;
    }

    void ShowDescription()
    {
        ObjectDescription description = coverHit.collider.gameObject.GetComponent<ObjectDescription>();
        if (description != null)
        {
            currentDescription = description.gameObject;
            ChangeLanguage();
        }
    }

    public void ChangeLanguage()
    {
        if(currentDescription!=null)
            Core.Description.text = currentDescription.GetComponent<ObjectDescription>().GetText(Core.GetLanguage());
    }

    private void leaveObject()
    {
        isClicked = false;
        if (!IconHidden)
        {
            currentIcon.SetActive(false);
            IconHidden = true;
        }

    }
}
