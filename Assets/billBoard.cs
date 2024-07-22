using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core_Utils;

public class billBoard : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        //mainCamera = Camera.main;
    }
    void LateUpdate()
    {
        if(rand.Next(0, 10000) == 1)
        {
            transform.LookAt(target.transform);
        }
        //transform.Rotate(0, 180, 0);
    }
}
