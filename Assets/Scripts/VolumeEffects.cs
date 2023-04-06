using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeEffects : MonoBehaviour
{
    private Volume volume;
    private ColorAdjustments colorAdjustments;
    private ChromaticAberration chromaticAberration;

    public bool noSaturation = false;
    public float defaultSaturation = 50;

    public bool chromaticAnimation = false;
    public float chromaticDefault = 0.2f;
    public float chromaticSpeed = 2f;
    private float chromaticIntensity = 0f;
    private bool chromaticIncreasing = true;

    public bool hueRainbow = false;
    private float hueShift = 0f;
    public float hueSpeed = 3f;

    public bool distortion = false;
    private LensDistortion lensDistortion;
    private float distortionIntensity = 0f;
    private bool distortionIncreasing = false;
    public float distortInSpeed;
    public float distortOutSpeed;

    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments) == false)
        {
            colorAdjustments = volume.profile.Add<ColorAdjustments>(true);
        }
        if (volume.profile.TryGet<ChromaticAberration>(out chromaticAberration) == false)
        {
            chromaticAberration = volume.profile.Add<ChromaticAberration>(true);
        }
        if (volume.profile.TryGet<LensDistortion>(out lensDistortion) == false)
        {
            lensDistortion = volume.profile.Add<LensDistortion>(true);
        }

    }

    void Update()
    {
        if (noSaturation)
        {
            ApplyNoSaturation();
        }
        else
        {
            ResetSaturation();
        }


        if (chromaticAnimation)
        {
            AnimateChromaticAberration();
        }
        else
        {
            chromaticAberration.intensity.Override(chromaticDefault);
        }

        if (hueRainbow)
        {
            AnimateHueShift();
        }
        else
        {
            colorAdjustments.hueShift.Override(0);
        }

        if (distortion)
        {
            AnimateLensDistortion();
        }
        else
        {
            lensDistortion.intensity.Override(0); // Reset to the default value when the effect is disabled
        }

    }

    void ApplyNoSaturation()
    {
        colorAdjustments.saturation.Override(-100);
    }

    void ResetSaturation()
    {
        colorAdjustments.saturation.Override(defaultSaturation); // Assuming default saturation value is 100
    }

    void AnimateChromaticAberration()
    {
        if (chromaticIncreasing)
        {
            chromaticIntensity += Time.deltaTime* chromaticSpeed;
            if (chromaticIntensity >= 1)
            {
                chromaticIntensity = 1;
                chromaticIncreasing = false;
            }
        }
        else
        {
            chromaticIntensity -= Time.deltaTime*chromaticSpeed;
            if (chromaticIntensity <= 0)
            {
                chromaticIntensity = 0;
                chromaticIncreasing = true;
            }
        }
        chromaticAberration.intensity.Override(chromaticIntensity);
    }

    void AnimateHueShift()
    {
        hueShift += Time.deltaTime * hueSpeed; // Adjust the speed of the hue shift by changing the multiplier
        if (hueShift > 180)
        {
            hueShift -= 360;
        }
        colorAdjustments.hueShift.Override(hueShift);
    }


    void AnimateLensDistortion()
    {
        if (distortionIncreasing)
        {
            distortionIntensity += Time.deltaTime * distortInSpeed;
            if (distortionIntensity >= 0)
            {
                distortionIntensity = 0;
                distortionIncreasing = false;
            }
        }
        else
        {
            distortionIntensity -= Time.deltaTime * distortOutSpeed;
            if (distortionIntensity <= -1)
            {
                distortionIntensity = -1;
                distortionIncreasing = true;
            }
        }
        lensDistortion.intensity.Override(distortionIntensity);
    }

}

