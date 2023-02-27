using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRotator : MonoBehaviour
{
    public float sensetivity = 100f;
    public float slowRotationFactor = 10f;
    private float sensetivityCurrent;
    public Transform orientation;
    //public Slider slider;
    public float xRotation;
    public float yRotation;
    private bool offsetSaved;
    private Quaternion startOffset;
    [SerializeField] private Pause pause;
    public void SaveOffset()
    {
        if (!offsetSaved && transform.childCount > 2)
            startOffset = (transform.GetChild(2).localRotation);
        offsetSaved = true;
    }
    public void Reset()
    {
        xRotation = 0;
        yRotation = 0;
        offsetSaved = false;
    }
    void LateUpdate()
    {
        //if (pause.isPaused)
         //   return;
        if (!Cursor.visible)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                sensetivityCurrent = sensetivity / slowRotationFactor;
            }
            else
                sensetivityCurrent = sensetivity;
            //mouseSensetivity = Mathf.Lerp(0.1f, 2, slider.value);
            float mouseX = (Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityCurrent);
            float mouseY = (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityCurrent);
            //float mouseX = 0;
            //float mouseY = 0;
            yRotation += mouseX;
            xRotation -= mouseY;


            if (transform.childCount > 2)
                transform.GetChild(2).localRotation = Quaternion.Euler(xRotation, yRotation, 0f) * startOffset;
            //transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f) * orientationKeeper.transform.localRotation;
            //transform.rotation = Quaternion.Euler(grabber.transform.rotation.eulerAngles.x, grabber.transform.rotation.eulerAngles.y, grabber.transform.rotation.eulerAngles.z) * Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}