using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //Settings
    public float Speed = 5.0f;
    public float Stamina = 10;
    public float MouseSpeed = 2.0f;
    public float SprintMultiplier = 2;
    public float jumpHeight = 1.5f;
    public float SlopeDetectorRange = 1f;
    public float SlopeDetectorOffset = 0f;
    public Transform cam;
    public CharacterController controller;
    public AudioClip[] audioClips;

    Vector3 rotation = Vector3.zero;
    private AudioSource Sound;
    private bool PlayerInMovement = false;
    private float CurrentStamina;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private float lastground;

    public void Start()
    {
        Sound = GetComponent<AudioSource>();
        CurrentStamina = Stamina;
        lastground = transform.position.y;
    }
    void Update()
    {
        //"Controls"
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        //if (CheckSlope(move, transform.position.y - lastground)) // slope detector off
        //{
        //    Debug.Log("Slope!");
        //    move = new Vector3(0, 0, 0);
        //}

        groundedPlayer = controller.isGrounded;


        if (!groundedPlayer)
            playerVelocity.y += gravityValue * Time.deltaTime * 2;
        else
        {
            playerVelocity.y = 0;
            lastground = transform.position.y;
        }

        PlayerInMovement = new Vector3(move.x, 0, move.z) != new Vector3(0, 0, 0);

        if (Input.GetButton("Sprint") && (CurrentStamina > 0))
        {
            move *= SprintMultiplier;
            CurrentStamina -= Time.deltaTime;
            if (CurrentStamina < 0)
            {
                CurrentStamina -= 2;
                Sound.clip = audioClips[0];
                Sound.Play();
            }

        }

        if(!Input.GetButton("Sprint") && CurrentStamina <Stamina)
            CurrentStamina += Time.deltaTime*4;

        if (CurrentStamina < 0)
            move *= 0.7f;

        if (Input.GetButtonDown("Jump") && (playerVelocity.y > -1 && playerVelocity.y < 1))
        {
            lastground = transform.position.y;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        //"Mouse";
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        if (rotation.x > 24) //Block player from rotating camera upwards and downwards too much
            rotation.x = 24;
        if (rotation.x < -24)
            rotation.x = -24;

        if(Time.timeScale!=0)
        {
            transform.eulerAngles = new Vector3(0, rotation.y, 0) * MouseSpeed;
            cam.transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0) * MouseSpeed;
            controller.Move(move * Speed * Time.deltaTime + playerVelocity * Time.deltaTime);
        }
    }



    bool CheckSlope(Vector3 direction, float deltajump)
    {
        direction = new Vector3(direction.x, SlopeDetectorOffset, direction.z);
        Vector3 source = new Vector3(transform.position.x, transform.position.y  - deltajump, transform.position.z);

        //Debug.DrawRay(source, new Vector3(direction.x, SlopeDetectorOffset, direction.z), Color.red);
        //Debug.DrawRay(source, new Vector3(direction.x + 0.8f, SlopeDetectorOffset, direction.z), Color.blue);
        //Debug.DrawRay(source, new Vector3(direction.x - 0.8f, SlopeDetectorOffset, direction.z), Color.blue);

        return Physics.Raycast(source, Quaternion.Euler(0, -20, 0) * direction, SlopeDetectorRange) ||
            Physics.Raycast(source, Quaternion.Euler(0, 20, 0) * direction, SlopeDetectorRange) || 
            Physics.Raycast(source, Quaternion.Euler(0, -35, 0)* direction, SlopeDetectorRange) ||
            Physics.Raycast(source, Quaternion.Euler(0, 35, 0) * direction, SlopeDetectorRange) ||
            Physics.Raycast(source, direction, SlopeDetectorRange);
    }

    public bool IsPlayerMoving()
    {
        return PlayerInMovement;
    }
}
