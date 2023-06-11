using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public GameObject grabber;
    public float sensetivityX, sensetivityY = 100f;
    public Transform orientation;
    public bool clamp;
    public bool onPlayer;
   // public Slider slider;
    private float mouseSensetivity;
    float xRotation;
    float yRotation;
    //[SerializeField] private Pause pause;
    public Quaternion startOffset;
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
    }
    void LateUpdate()
    {
        //if (pause.isPaused)
        //    return;
        if (!Cursor.visible)
        {
            // mouseSensetivity = Mathf.Lerp(0.1f, 2, slider.value);
            mouseSensetivity = 1;
            float mouseX = (Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityX*mouseSensetivity);
            float mouseY = (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityY*mouseSensetivity);

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // constraints
       
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
