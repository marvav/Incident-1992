using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    public PlayerMovementDen player;
    public float bobbingStrength;
    public float speed = 1.0f;
    public float sprintSpeed = 2.0f;
    public float offset = 0.0f;
    private Vector3 orgPosition;

    void Start()
    {
        orgPosition = this.gameObject.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (player.isMoving()) //Perform View Bobbing
        {
            this.gameObject.transform.localPosition = new Vector3(orgPosition.x,
                orgPosition.y + ((float)Math.Sin(Time.fixedTimeAsDouble * (player.isPlayerSprinting() ? sprintSpeed : speed) + offset)) * bobbingStrength,
                orgPosition.z);
        }
        else
        {
            this.gameObject.transform.localPosition = orgPosition;
        }
    }
}
