using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoard : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        //mainCamera = Camera.main;
    }
    void LateUpdate()
    {
        transform.LookAt(target.transform);
        //transform.Rotate(0, 180, 0);
    }
}
