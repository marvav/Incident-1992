using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class BlinkingLight : MonoBehaviour
{
    public int blinking_intensity;
    public int intensity;
    private Light light;
    private bool isFlickering;

    void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        if (!isFlickering && rand.Next(0, blinking_intensity) == 1)
        {
            isFlickering = true;
        }
        if (isFlickering)
        {
            int random = rand.Next(0, 5000);
            if (random > 4500)
            {
                light.intensity = rand.Next(0, intensity);
            }
            if (random < 10)
            {
                isFlickering = false;
            }
        }
    }
}
