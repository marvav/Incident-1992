using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject FlashLight;

    // Update is called once per frame
    void Update()
    {
        Player.SetActive(false);
        FlashLight.SetActive(false);
    }
}
