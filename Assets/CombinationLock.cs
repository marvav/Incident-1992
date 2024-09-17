using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class CombinationLock : MonoBehaviour
{
    public int[] correctDigits = new int[4];
    public int[] digits = new int[4];
    public GameObject Reward;
    public GameObject TurnOffAfter;
    public OpenIcon exitIcon;

    public void changeDigit(int index, int value)
    {
        digits[index] += value;
        if (digits[index] > 9)
            digits[index] -= 10;
        if (digits[index] < 0)
            digits[index] += 10;
        isCorrect();
    }

    public void isCorrect()
    {
        if (correctDigits[0] == digits[0] &&
            correctDigits[1] == digits[1] &&
            correctDigits[2] == digits[2] &&
            correctDigits[3] == digits[3])
        {
            Reward.SetActive(true);
            TurnOffAfter.SetActive(false);
            exitIcon.ForceClickAction();
            this.gameObject.SetActive(false);
        }
    }
}
