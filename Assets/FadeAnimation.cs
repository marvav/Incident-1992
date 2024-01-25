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
    public bool isDeath = false;

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 0;
        float gain = Time.deltaTime;
        if (fadeIn)
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a + gain * speedScreen < 1 ? tempColor.a + gain * speedScreen : 1;
            screen.color = tempColor;
            tempColor = black.color;
            tempColor.a = tempColor.a + gain * speedBlack < 1 ? tempColor.a + gain * speedBlack : 1;
            black.color = tempColor;
            Debug.Log(screen.color.a);
            if (screen.color.a == 1)
            {
                Continue();
            }
        }
        else
        {
            var tempColor = screen.color;
            tempColor.a = tempColor.a - gain * speedScreen > 0 ? tempColor.a - gain * speedScreen : 0;
            screen.color = tempColor;
            tempColor = black.color;
            tempColor.a = tempColor.a - gain * speedBlack > 0 ? tempColor.a - gain * speedBlack : 0;
            black.color = tempColor;
            if (screen.color.a ==0)
                Continue();
        }
    }
    void Continue()
    {
        if(isDeath)
            Core.DeathHUD.SetActive(true);
        if(next!=null)
            next.SetActive(true);
        this.gameObject.GetComponent<FadeAnimation>().enabled = false;
    }
}
