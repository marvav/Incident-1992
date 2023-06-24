using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multitext : MonoBehaviour
{
    private TMP_Text text;
    public string[] texts;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = texts[0];
    }
    public void ChangeLanguage(int value)
    {
        text.text = texts[value];
    }
}
