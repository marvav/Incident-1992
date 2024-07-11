using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public float sensetivityX, sensetivityY = 100f;
    public Transform orientation;
    public Transform player;
    private float mouseSensetivity;
    public float xRotation;
    public float yRotation;

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
            // mouseSensetivity = Mathf.Lerp(0.1f, 2, slider.value);
            mouseSensetivity = 1;
            float mouseX = (Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityX*mouseSensetivity);
            float mouseY = (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityY*mouseSensetivity);

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // constraints

            orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
