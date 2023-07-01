using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateStatistics : MonoBehaviour
{
    public Core Core;
    public TMP_Text cluesDiscovered;
    // Start is called before the first frame update
    void Start()
    {
        cluesDiscovered.text += " " + Core.ProgressManager.getFoundCluesCount().ToString() + "/" + Core.ProgressManager.id_list.Length.ToString();
    }
}
