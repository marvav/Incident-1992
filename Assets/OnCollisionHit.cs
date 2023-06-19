using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionHit : MonoBehaviour
{
    public Core Core;
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        Core.Hurt(damage);
    }
}
