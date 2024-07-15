using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public float sensetivityX, sensetivityY = 100f;
    public float bobbingStrength = 1.0f;
    public Transform orientation;
    public Transform player;
    public Transform head;
    public PlayerMovementDen playerMovement;

    private float mouseSensetivity;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    public void SetSensitivity(float sensitivity)
    {
        sensetivityX = sensitivity;
        sensetivityY = sensitivity;
    }
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }
    void LateUpdate()
    {
        if (!Cursor.visible)
        {
            float mouseX = (Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityX);
            float mouseY = (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityY);

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // constraints

            orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            player.rotation = Quaternion.Euler(0, yRotation, 0);

            if (playerMovement.isMoving()) //Perform View Bobbing
            {
                orientation.position = new Vector3(head.position.x,
                    head.position.y + ((float) Math.Sin(Time.fixedTimeAsDouble * 10))* bobbingStrength,
                    head.position.z);
            }
            else
            {
                orientation.position = head.position;
            }
        }
    }
}
