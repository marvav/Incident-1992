using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public Core Core;
    public GameObject Scene;

    void OnTriggerEnter(Collider other)
    {
        Core.DeathManager.DepthEndingScreen();
        Scene.SetActive(true);
    }
}
