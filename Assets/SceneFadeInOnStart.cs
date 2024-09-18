using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeInOnStart : MonoBehaviour
{
    public Core Core;
    public UnityEngine.UI.Image image;
    public float fadeInSpeed = 0.1f;
    public float fadeInStrength = 0.1f;
    void Start()
    {
        Core.DeathManager.Screen(image, fadeInStrength, fadeInSpeed, 0.0f, 0.0f);
    }
}
