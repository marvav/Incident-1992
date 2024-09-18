using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeEffects : MonoBehaviour
{
    private Volume volume;
    private ChromaticAberration chromaticAberration;

    public float chromaticDefault = 0.2f;
    public float chromaticSpeed = 2f;
    public float animatedChromaticIntensity = 3.0f;

    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet<ChromaticAberration>(out chromaticAberration) == false)
        {
            chromaticAberration = volume.profile.Add<ChromaticAberration>(true);
        }

    }

    public void SetChromaticAberrationAnimation(bool chromaticAnimation)
    {
        chromaticAberration.intensity.Override(chromaticAnimation 
            ? animatedChromaticIntensity 
            : chromaticDefault);
    }

}

