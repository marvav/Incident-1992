using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScene : MonoBehaviour
{
    public Core Core;
    public UnityEngine.UI.Image blackBackground;
    public UnityEngine.UI.Image badEndingImage;
    public UnityEngine.UI.Image carEndingImage;
    public UnityEngine.UI.Image depthEnding;
    public UnityEngine.UI.Image escapeEnding;
    public UnityEngine.UI.Image YouGotShotEnding;
    public float fadeInSpeed = 1f;
    public float fadeInStrength = 0.1f;
    public bool isScreenReady = false;
    private float slowSpeed = 0.002f;

    public void YouGotShotEndingScreen()
    {
        Screen(YouGotShotEnding, slowSpeed, slowSpeed);
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic);
    }

    public void EscapeEndingScreen()
    {
        Screen(escapeEnding, slowSpeed, slowSpeed);
        Core.AudioManager.PlayMusic(Core.AudioManager.EscapeEndingMusic);
    }

    public void DepthEndingScreen()
    {
        Screen(depthEnding, slowSpeed, slowSpeed);
        Core.AudioManager.PlayMusic(Core.AudioManager.DepthEndingMusic);
    }

    public void CarEndingScreen()
    {
        Screen(carEndingImage, slowSpeed, slowSpeed);
        Core.AudioManager.PlayMusic(Core.AudioManager.CarEndingMusic);
    }

    public void BadEndingScreen() {
        Screen(badEndingImage, slowSpeed, slowSpeed);
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic);
    }

    public void Screen(UnityEngine.UI.Image image)
    {
        Screen(image, fadeInStrength, fadeInSpeed);
    }

    public void Screen(UnityEngine.UI.Image image, float fadeInStrength, float fadeInSpeed)
    {
        image.gameObject.SetActive(true);
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;
        StartCoroutine(FadeInBackground(image, fadeInStrength*2, fadeInSpeed*2));
        StartCoroutine(FadeInScreen(image, fadeInStrength, fadeInSpeed));
    }

    IEnumerator FadeInBackground(UnityEngine.UI.Image screen, float fadeInStrength, float fadeInSpeed)
    {
        do
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a + fadeInStrength;
            screen.color = tempColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        while (screen.color.a < 1.0f);
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
        Core.DeathHUD.SetActive(true);
    }

    public bool isScreenShown()
    {
        return isScreenReady;
    }
}