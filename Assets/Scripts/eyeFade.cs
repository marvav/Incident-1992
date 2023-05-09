using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeFade : MonoBehaviour
{
    
    public Light flashlight;
    private MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(flashlight.enabled)
            renderer.enabled = false;
        else
            renderer.enabled = true;
    }
}
