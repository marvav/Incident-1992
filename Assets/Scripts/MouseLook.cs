using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	Vector2 rotation = Vector2.zero;
    public float MouseSpeed = 3;

    void Update()
	{
        //"Mouse";
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        if (rotation.x > 24) //Block player from rotating camera upwards and downwards too much
        {
            rotation.x = 24;
        }
        if (rotation.x < -24)
        {
            rotation.x = -24;
        }
        transform.eulerAngles = (Vector3)rotation * MouseSpeed;
    }
}
