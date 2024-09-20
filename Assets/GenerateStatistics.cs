using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateStatistics : MonoBehaviour
{
    public Core Core;
    public TMP_Text cluesDiscovered;

    void Update() {
        cluesDiscovered.text = "";
        addLine("Clues Discovered: " + Core.ProgressManager.getFoundCluesCount().ToString() + "/" + Core.ProgressManager.AllClueCount());
        addLine("Casettes Played: " + Core.ProgressManager.getFoundCluesCount().ToString() + "/" + Core.ProgressManager.playedCasettesCount());
    }

    private void addLine(string line)
    {
        cluesDiscovered.text += line + "\n";
    }
}
