using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding : MonoBehaviour
{
    public Core Core;
    public GameObject badEndingMonster;
    public GameObject cutRope;
    public GameObject escapeRope;
    void Start()
    {
        badEndingMonster.SetActive(true);
        if (Core.ProgressManager.vanSabotaged) {
            cutRope.SetActive(true);
            Core.RollingText.RollText("What was that?! The remaining guy must have cut off my rope!", 1);
        }
        else
        {
            escapeRope.SetActive(true);
            Core.RollingText.RollText("RUN!", 0);
        }
    }
}
