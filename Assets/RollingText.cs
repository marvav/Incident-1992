using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Core_Utils;

public class RollingText : MonoBehaviour
{
    public Core Core;
    public TMP_Text text;
    public float afterCharWait = 0.05f;
    public float afterSentenceWait = 1.5f;
    public float afterWholeWait = 2.0f;

    public void RollText(string text)
    {
        StartCoroutine(write(text));
    }

    IEnumerator write(string queue)
    {
        int queueIndex = 0;
        text.text = "";

        while (queue.Length > queueIndex)
        {
            text.text += queue[queueIndex];
            queueIndex++;
            if (text.text.Length > 1 && text.text[text.text.Length - 1] == ' ' && text.text[text.text.Length - 2] == '.')
            {
                yield return new WaitForSeconds(afterSentenceWait);
            }
            else
            {
                yield return new WaitForSeconds(afterCharWait);
            }
        }
        yield return new WaitForSeconds(afterWholeWait);
        text.text = "";
    }
}