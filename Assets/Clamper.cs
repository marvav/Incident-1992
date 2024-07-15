using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamper : MonoBehaviour
{
    public GameObject target;
    public GameObject clamp;
    public float x, y, z;

    // Update is called once per frame
    void FixedUpdate()
    {
        clamp.transform.position = target.transform.position + new Vector3(x,y,z);
    }
}
