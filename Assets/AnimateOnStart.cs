using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnStart : MonoBehaviour
{
    public Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation.Play();
    }
}
