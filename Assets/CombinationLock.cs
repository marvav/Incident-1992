using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class CombinationLock : MonoBehaviour
{
    public int[] correctDigits = new int[4];
    public int[] digits = new int[4];
    public GameObject HUD;
    public GameObject Lock;
    public GameObject Reward;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            correctDigits[i] = rand.Next(0,10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HUD.SetActive(true);
        if (Input.GetButtonDown("Escape"))
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
            Lock.SetActive(false);
            HUD.SetActive(false);
            Reward.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
