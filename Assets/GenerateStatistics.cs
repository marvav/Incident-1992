using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateStatistics : MonoBehaviour
{
    public Core Core;
    public TMP_Text cluesDiscovered;

    void Update()
    {
        cluesDiscovered.text = "Clues Discovered: " + Core.ProgressManager.getFoundCluesCount().ToString() + "/" + Core.ProgressManager.AllClueCount();
    }
}
