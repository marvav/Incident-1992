using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public Core Core;
    public Camera cameraStats;
    public PlayerCamera cam;
    public Slider sensitivity;
    public Slider gamma;
    public Slider Localization;
    //public Slider QualityLevel;
    public Slider MaxFPS;
    public TMP_Text fps_count;

    void Start()
    {
        gamma.value = Core.startingGamma;
    }
    // Update is called once per frame
    void Update()
    {
        forceSettings();
        fps_count.text = "Max FPS: " + Application.targetFrameRate.ToString();
    }

    public void forceSettings()
    {
        RenderSettings.ambientLight = new Color(gamma.value, gamma.value, gamma.value, 1.0f);
        cam.SetSensitivity(sensitivity.value);
        Application.targetFrameRate = (int) MaxFPS.value;
        //Core.ChangeLanguage((int) Localization.value);
        //QualitySettings.SetQualityLevel((int) QualityLevel.value);
    }
}
