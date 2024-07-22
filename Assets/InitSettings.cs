using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSettings : MonoBehaviour
{
    public AudioSettings AudioSettings;
    public Settings GeneralSettings;
    void Start()
    {
        AudioSettings.forceSettings();
        GeneralSettings.forceSettings();
    }
}
