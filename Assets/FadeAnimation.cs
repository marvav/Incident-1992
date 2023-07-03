using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    public Core Core;
    public GameObject next;
    public UnityEngine.UI.Image screen;
    public UnityEngine.UI.Image black;
    public float speedScreen = 1.0f;
    public float speedBlack = 1.0f;
    public bool fadeIn = true;

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 0;
        if (fadeIn && screen.color.a < 255)
        {
            var tempColor = screen.color;
            tempColor.a += Time.deltaTime * speedScreen;
            screen.color = tempColor;
            tempColor = black.color;
            tempColor.a += Time.deltaTime * speedBlack;
            black.color = tempColor;
            if (screen.color.a >= 255)
            {
                Core.DeathHUD.SetActive(true);
                this.gameObject.GetComponent<FadeAnimation>().enabled = false;
                next.SetActive(true);
            }
        }
        if(!fadeIn && screen.color.a > 255)
        {
            var tempColor = screen.color;
            tempColor.a -= Time.deltaTime * speedScreen;
            screen.color = tempColor;
            tempColor = black.color;
            tempColor.a -= Time.deltaTime * speedBlack;
            black.color = tempColor;
            if (screen.color.a <=0)
            {
                Core.DeathHUD.SetActive(true);
                this.gameObject.GetComponent<FadeAnimation>().enabled = false;
                next.SetActive(true);
            }
        }
    }
}
