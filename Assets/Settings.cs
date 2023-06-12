using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public PlayerCamera cam;
    public Slider sensitivity;

    // Update is called once per frame
    void Update()
    {
        cam.SetSensitivity(sensitivity.value);
    }
}
