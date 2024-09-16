using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEnding : MonoBehaviour
{
    public Core Core;
    public GameObject cutRope;
    public GameObject ropeExited;
    void Start()
    {
        if (Core.ProgressManager.vanSabotaged) {

            cutRope.SetActive(true);
            Core.RollingText.RollText("What was that?! The remaining guy must have cut off my rope!", 1);
        }
        else
        {
            ropeExited.SetActive(true);
            Core.RollingText.RollText("Is the monster coming for the knife?!");
        }
    }
}
