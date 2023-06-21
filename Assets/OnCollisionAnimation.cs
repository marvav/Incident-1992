using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAnimation : MonoBehaviour
{
    public Animation Animation;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (Animation.isPlaying && collision.gameObject.layer == 7)
        {
            Debug.Log("stopped");
            Animation.Stop();
            //Animation[Animation.clip].speed = 0;
        }
    }
}