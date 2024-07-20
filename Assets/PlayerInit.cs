using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public Core Core;

    void Start()
    {
        Core.ProgressManager.changeObjective(0);
    }
}
