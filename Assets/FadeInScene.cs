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
    public UnityEngine.UI.Image EscapeNewspaper;
    public float fadeInSpeed = 1f;
    public float fadeInStrength = 0.1f;
    public bool isScreenReady = false;
    private float slowSpeed = 0.002f;
    private float extremeSlowSpeed = 0.000025f;

    public void YouGotShotEndingScreen()
    {
        DeathScreen(YouGotShotEnding, slowSpeed, slowSpeed, 0.0f, 0.0f);
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic, true);
    }

    public void EscapeEndingScreen()
    {
        DeathScreen(escapeEnding, slowSpeed, slowSpeed, 0.0f, 25.0f);
        Core.AudioManager.PlayMusic(Core.AudioManager.EscapeEndingMusic, true);
        Screen(EscapeNewspaper, extremeSlowSpeed, extremeSlowSpeed, 15.0f, 0.0f);
    }

    public void DepthEndingScreen()
    {
        DeathScreen(depthEnding, slowSpeed, slowSpeed, 0.0f, 25.0f);
        Core.AudioManager.PlayMusic(Core.AudioManager.DepthEndingMusic, true);
    }

    public void CarEndingScreen()
    {
        DeathScreen(carEndingImage, slowSpeed, slowSpeed, 0.0f, 0.0f);
        Core.AudioManager.PlayMusic(Core.AudioManager.CarEndingMusic, true);
    }

    public void BadEndingScreen() {
        DeathScreen(badEndingImage, slowSpeed, slowSpeed, 0.0f, 0.0f);
        Core.AudioManager.PlayMusic(Core.AudioManager.BadEndingMusic, true);
    }

    public void Screen(UnityEngine.UI.Image image)
    {
        Screen(image, fadeInStrength, fadeInSpeed, 0.0f, 0.0f);
    }

    public void DeathScreen(UnityEngine.UI.Image image, float fadeInStrength, float fadeInSpeed, float waitBefore, float waitAfter)
    {
        Core.StopPlayer();

        image.gameObject.SetActive(true);
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;

        StartCoroutine(FadeInScreen(blackBackground, fadeInStrength*2, fadeInSpeed*2, 0.0f, 0.0f));
        StartCoroutine(FadeInDeathScreen(image, fadeInStrength, fadeInSpeed, waitBefore, waitAfter));
    }

    public void Screen(UnityEngine.UI.Image image, float fadeInStrength, float fadeInSpeed, float waitBefore, float waitAfter)
    {
        Core.StopPlayer();

        image.gameObject.SetActive(true);
        var tempColor = image.color;
        tempColor.a = 0.0f;
        image.color = tempColor;

        StartCoroutine(FadeInScreen(blackBackground, fadeInStrength * 2, fadeInSpeed * 2, 0.0f, 0.0f));
        StartCoroutine(FadeInScreen(image, fadeInStrength, fadeInSpeed, waitBefore, waitAfter));
    }

    IEnumerator FadeInScreen(UnityEngine.UI.Image screen, float fadeInStrength, float fadeInSpeed, float waitBefore, float waitAfter)
    {
        yield return new WaitForSeconds(waitBefore);
        do
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a + fadeInStrength;
            screen.color = tempColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        while (screen.color.a < 1.0f);
        yield return new WaitForSeconds(waitAfter);
    }

    IEnumerator FadeInDeathScreen(UnityEngine.UI.Image screen, float fadeInStrength, float fadeInSpeed, float waitBefore, float waitAfter)
    {
        yield return new WaitForSeconds(waitBefore);
        do
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a + fadeInStrength;
            screen.color = tempColor;
            yield return new WaitForSeconds(fadeInSpeed);
        }
        while (screen.color.a < 1.0f);
        yield return new WaitForSeconds(waitAfter);
        isScreenReady = true;
        Core.DeathHUD.SetActive(true);
    }

    public bool isScreenShown()
    {
        return isScreenReady;
    }
}