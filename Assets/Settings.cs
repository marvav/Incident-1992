using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public Core Core;
    public Camera cameraStats;
    public Slider sensitivity;
    public Slider gamma;
    public Slider Localization;
    public Slider QualityLevel;
    public Slider TargetFPS;
    public TMP_Text fps_count;
    public TMP_Text quality;

    void Start()
    {
        //TargetFPS.value = Screen.currentResolution.refreshRate;
        TargetFPS.value = 60;
        gamma.value = Core.startingGamma;
    }
    // Update is called once per frame
    void Update()
    {
        forceSettings();
        fps_count.text = "Target FPS: " + Application.targetFrameRate.ToString();
        quality.text = "Quality: " + getQualityName(QualitySettings.GetQualityLevel());
    }

    public void forceSettings()
    {
        RenderSettings.ambientLight = new Color(gamma.value, gamma.value, gamma.value, 1.0f);
        Core.PlayerDen.SetSensitivity(sensitivity.value);
        Application.targetFrameRate = (int) TargetFPS.value;
        //Core.ChangeLanguage((int) Localization.value);
        //QualitySettings.SetQualityLevel((int) QualityLevel.value);
    }

    private string getQualityName(int value)
    {
        switch (value)
        {
            case 1:
                return "Low";
            case 2:
                return "Medium";
            default:
                return "High";
        };
    }
}
