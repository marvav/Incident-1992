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
    void Update()
    {
        CanPickup = false;
        if (CastRayHand(InteractionDistance, out coverHit) && !isGamePaused())
        {
            if(lastObject!= coverHit.collider.gameObject)
                leaveObject();

            if (coverHit.collider.gameObject.tag == "Description")
                ShowDescription();
            else
                Core.Description.text = "";

            if (coverHit.collider.gameObject.layer != 7 && coverHit.distance > InteractionDistance / 2)
                return;

            //Debug.Log(coverHit.collider.gameObject.name);
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
                        HandleEIteraction();
                        return;
                    }
                case 13:
                    {
                        HandleLMBIteraction();
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
        {
            Core.Description.text = "";
            leaveObject();
        }
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
        if (description != null && Core.RollingText.isEmpty() && Core.Subtitles.text.Length == 0)
        {
            currentDescription = description.gameObject;
            ChangeLanguage();
        }
        else
        {
            Core.Description.text = "";
        }
    }

    public void ChangeLanguage()
    {
        if (currentDescription != null)
        {
            Core.Description.text = currentDescription.GetComponent<ObjectDescription>().GetText(Core.GetLanguage());
        }
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

    private bool isGamePaused()
    {
        return Time.timeScale == 0;
    }

    private void HandleLMBIteraction()
    {
        ShowDescription();
        ToggleObject[] toggleObjects = coverHit.collider.gameObject.GetComponents<ToggleObject>();
        InteractionTeleport teleport = null;
        if (toggleObjects.Length == 0)
        {
            teleport = coverHit.collider.gameObject.GetComponent<InteractionTeleport>();
            SwapIcons(teleport.icon);
        }
        else
            SwapIcons(toggleObjects[0].icon); // Icon of the 1st toggle component is used

        if (Input.GetMouseButtonDown(0))
        {
            if (!isClicked)
            {
                currentIcon.SetActive(false);
                isClicked = true;
                if (toggleObjects.Length > 0)
                { // All valid toggles are triggered
                    foreach (ToggleObject toggle in toggleObjects)
                    {
                        toggle.Toggle();
                    }
                }
                else
                    teleport.Teleport();

            }
        }
        else
            isClicked = false;
    }

    private void HandleEIteraction()
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
    }
}
