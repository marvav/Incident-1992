using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Core Core;
    public Camera cameraStats;
    public PlayerCamera cam;
    public Slider sensitivity;
    public Slider gamma;
    public Slider fov;

    void Start()
    {
        gamma.value = Core.startingGamma;
    }
    // Update is called once per frame
    void Update()
    {
        RenderSettings.ambientLight = new Color(gamma.value, gamma.value, gamma.value, 1.0f);
        cam.SetSensitivity(sensitivity.value);
        cameraStats.fieldOfView = fov.value;
    }
}
