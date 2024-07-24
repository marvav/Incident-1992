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

    private bool isWritingState = false;

    public bool isWriting()
    {
        return isWritingState;
    }

    public void RollText(string text)
    {
        Debug.Log("rolling");
        isWritingState = true;
        RollText(text, 0, afterWholeWait);
    }

    public void RollText(string text, int waitBeforeStart)
    {
        StartCoroutine(write(text, waitBeforeStart, afterWholeWait));
    }

    public void RollText(string text, int waitBeforeStart, float afterWholeWait)
    {
        StartCoroutine(write(text, waitBeforeStart, afterWholeWait));
    }

    IEnumerator write(string queue, int waitBeforeStart, float afterWholeWait)
    {
        int queueIndex = 0;
        yield return new WaitForSeconds(waitBeforeStart);
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
        text.text = "";
        isWritingState = false;
        yield return new WaitForSeconds(afterWholeWait);
    }
}