using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class RollingText : MonoBehaviour
{

    public Core Core;
    public TMP_Text text;
    public float writingSpeed = 1.0f;

    public void RollText(string text)
    {
        StartCoroutine(write(text));
    }

    IEnumerator write(string queue)
    {
        int queueIndex = 0;
        float queueTime = 0.0f;
        float pile = 0.0f;
        text.text = "";

        while (queue.Length > queueIndex)
        {
            if (queueTime > 0)
            {
                pile += Time.deltaTime;
                if (pile >= writingSpeed)
                {
                    pile -= writingSpeed;
                    queueTime -= writingSpeed;
                    text.text += queue[queueIndex];
                    queueIndex++;
                    if (text.text.Length > 1 && text.text[text.text.Length - 1] == ' ' && text.text[text.text.Length - 2] == '.')
                    {
                        yield return new WaitForSeconds(1.5f);
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.05f);
                    }
                }
            }
        }
        stop();
    }

    void stop()
    {
        text.text = "";
    }
}