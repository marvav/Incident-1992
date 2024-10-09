using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Core Core;
    public GameObject Scene;

    void Start()
    {
        Core.RollingText.RollText("What was that?!", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Core.DeathManager.DepthEndingScreen();
        Scene.SetActive(true);
    }
}
