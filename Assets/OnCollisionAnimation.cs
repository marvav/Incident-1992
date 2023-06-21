using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAnimation : MonoBehaviour
{
    public Animation Animation;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (Animation.isPlaying && collision.gameObject.tag == "Pickable")
        {
            Animation.Stop();
            //Animation[Animation.clip].speed = 0;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision ended");
    }
}
