using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScene : MonoBehaviour
{
    public Core Core;
    public UnityEngine.UI.Image badEndingImage;
    public UnityEngine.UI.Image carEndingImage;
    public UnityEngine.UI.Image depthEnding;
    public UnityEngine.UI.Image escapeEnding;
    public float fadeInSpeed = 1f;
    public float fadeInStrength = 0.1f;
    public bool isScreenReady = false;

    public void EscapeEndingScreen()
    {
        Screen(escapeEnding);
        escapeEnding.gameObject.SetActive(true);
        Core.AudioManager.PlayMusic(Core.AudioManager.EscapeEndingMusic);
    }

    public void DepthEndingScreen()
    {
        Screen(depthEnding);
        depthEnding.gameObject.SetActive(true);
        Core.AudioManager.PlayMusic(Core.AudioManager.DepthEndingMusic);
    }

    public void CarEndingScreen()
    {
        Screen(carEndingImage);
        carEndingImage.gameObject.SetActive(true);
        Core.AudioManager.PlayMusic(Core.AudioManager.CarEndingMusic);
    }

    public void BadEndingScreen() {
        badEndingImage.gameObject.SetActive(true);
        Screen(badEndingImage);
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic);
    }

    public void Screen(UnityEngine.UI.Image image)
    {
        Screen(image, fadeInStrength, fadeInSpeed);
    }

    public void Screen(UnityEngine.UI.Image image, float fadeInStrength, float fadeInSpeed)
    {
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;
        StartCoroutine(FadeInScreen(image, fadeInStrength, fadeInSpeed));
    }

    IEnumerator FadeInScreen(UnityEngine.UI.Image screen, float fadeInStrength, float fadeInSpeed)
    {
        do
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a + fadeInStrength;
            screen.color = tempColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        while (screen.color.a < 1.0f);
        isScreenReady = true;
    }

    public bool isScreenShown()
    {
        return isScreenReady;
    }
}