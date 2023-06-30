using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    public int[] correctDigits = new int[4];
    public int[] digits = new int[4];
    public GameObject HUD;
    public GameObject Icon;
    public GameObject Reward;

    // Update is called once per frame
    void Update()
    {
        Icon.SetActive(false);
        HUD.SetActive(true);
        if (Input.GetButtonDown("Pick Up"))
        {
            HUD.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

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
            HUD.SetActive(false);
            Reward.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
