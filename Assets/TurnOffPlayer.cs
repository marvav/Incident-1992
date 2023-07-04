using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject FlashLight;
    public bool state;

    // Update is called once per frame
    void Update()
    {
        Player.GetComponent<PlayerMovementDen>().enabled = state;
        FlashLight.GetComponent<FlashLightComponent>().enabled = state;
    }
}
