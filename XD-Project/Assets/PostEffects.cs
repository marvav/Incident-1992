using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class OnValueChangedText : MonoBehaviour
{
    private Text ValueText;

    private void Start()
    {
        ValueText = GetComponent<Text>();
    }

    public void OnSliderValueChanged(float value)
    {
        ValueText.text = value.ToString("0.00");
    }
}