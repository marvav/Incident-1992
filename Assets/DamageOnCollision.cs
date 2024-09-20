using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public Core Core;
    public AudioSource sound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            sound.Stop();
            Core.Hurt(3, Core.DeathType.Electricity);
            sound.Play();
        }
    }
}
