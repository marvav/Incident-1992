using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSteps : MonoBehaviour
{

    public float triggerMagnitude;
    public PlayerSounds playerSounds;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > triggerMagnitude)
            playerSounds.FallSound(collision);
    }
}
