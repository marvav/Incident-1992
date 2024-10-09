using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovementDen : MonoBehaviour
{
    public Core Core;
    public monsterFollow monster;
    float speed;
    public float moveSpeed;

    public int stamina;
    public int staminaRechargeSpeed;
    public float staminaDrainedMultiplier;
    public AudioSource staminaPanting;

    public float speedCoeficient;
    public float safeZoneSpeedCoeficient;
    public float holdingObjectSpeedCoeficient;

    public float groundDrag, airDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float sprintMultiplier;
    bool readyToJump;

    public Vector3 velocity;
    public float gravity;

    public GameObject groundCheck;
    public Collider Body;
    public GrabbingController GrabbingController;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crawlKey = KeyCode.LeftControl;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private string floorTag = "";
    private Collider[] groundArray;
    public bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private float currentStamina;
    public bool staminaDrained = false;
    public bool isSprinting = false;

    public float heightHurtThreshold;
    private bool landAndHurt = false;
    public bool isInSafeZone = false;

    public float waterSpeedMultiplier;
    public float asphaltSpeedMultiplier;

    private Vector3 teleportCoordinates;
    private bool teleportPlayer;

    public float sensetivityX, sensetivityY = 100f;
    public float bobbingStrength = 1.0f;

    public Transform head;
    public Transform camera;

    private float mouseSensetivity;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        currentStamina = stamina;

        readyToJump = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        groundArray = Physics.OverlapSphere(groundCheck.transform.position, groundCheck.GetComponent<SphereCollider>().radius * gameObject.transform.localScale.x, whatIsGround);
        grounded = groundArray.Length != 0 && groundArray[0].gameObject != GrabbingController.GetHeldObject();

        if (grounded)
            floorTag = groundArray[0].gameObject.tag;
        else
            floorTag = "";

        MyInput();
        SpeedControl(floorTag);
        HandleFallDamage();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = airDrag;

        if (teleportPlayer)
        {
            this.gameObject.transform.position = teleportCoordinates;
            teleportPlayer = false;
        }
        else
        {
            MovePlayer();
            RotatePlayer();
        }

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        speed = moveSpeed + verticalInput * moveSpeed * speedCoeficient;
        isSprinting = Input.GetKey(sprintKey) && verticalInput >= 0.2f && !staminaDrained;

        if (isInSafeZone)
        {
            speed *= safeZoneSpeedCoeficient;
        }

        if (GrabbingController.isHolding())
        {
            speed *= holdingObjectSpeedCoeficient;
        }

        if (isSprinting)
        {
            if (currentStamina > 0)
            {
                currentStamina -= Time.deltaTime;
                speed *= sprintMultiplier;
            }
            else
            {
                staminaDrained = true;
                staminaPanting.Play();
            }
        }

        if (staminaDrained)
        {
            speed *= staminaDrainedMultiplier;
            if (currentStamina > stamina / 2)
                staminaDrained = false;
        }

        if(!isSprinting && currentStamina < stamina)
            currentStamina += Time.deltaTime * staminaRechargeSpeed;

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && (grounded || gameObject.transform.parent != null))
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = this.transform.forward * verticalInput + this.transform.right * horizontalInput;

        if (grounded)
        {
            Body.material.dynamicFriction = 0.03f;
            velocity = Vector3.zero;
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        else
        {
            Body.material.dynamicFriction = 0;
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
            velocity.y += gravity * Time.deltaTime;
            rb.velocity += velocity;
        }
    }

    private void RotatePlayer()
    {
        if (!Cursor.visible)
        {
            float mouseX = (Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensetivityX);
            float mouseY = (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensetivityY);

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // constraints

            camera.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            this.transform.rotation = Quaternion.Euler(0, yRotation, 0);

            if (isMoving()) //Perform View Bobbing
            {
                camera.position = new Vector3(head.position.x,
                    head.position.y + ((float)Math.Sin(Time.fixedTimeAsDouble * 10)) * bobbingStrength,
                    head.position.z);
            }
            else
            {
                camera.position = head.position;
            }
        }
    }

    private void SpeedControl(string floorTag)
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        switch (floorTag)
        {
            case "Water":
                {
                    speed *= waterSpeedMultiplier;
                    break;
                }
            case "Asphalt":
                {
                    speed *= asphaltSpeedMultiplier;
                    break;
                }
        }

        // limit velocity if needed
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Leave any "holding" object like a moving platform
        if (gameObject.transform.parent != null) gameObject.transform.parent = null;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public bool isMoving()
    {
        return horizontalInput != 0 || verticalInput != 0;
    }

    public bool isPlayerSprinting()
    {
        return isSprinting;
    }

    public string GetFloor()
    {
        return floorTag;
    }

    public void HandleFallDamage()
    {
        if(rb.velocity.y > -0.1f && landAndHurt)
        {
            Core.Hurt(2, Core.DeathType.Fall);
            landAndHurt = false;
        }
        landAndHurt = landAndHurt || rb.velocity.y < heightHurtThreshold;
    }

    public bool isPlayerInSafeZone()
    {
        return isInSafeZone;
    }

    public void TeleportPlayer(Vector3 destination)
    {
        teleportCoordinates = destination;
        teleportPlayer = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SafeZone" && !isInSafeZone)
        {
            isInSafeZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "SafeZone" && isInSafeZone)
        {
            isInSafeZone = false;
        }
    }

    public void SetSensitivity(float sensitivity)
    {
        sensetivityX = sensitivity;
        sensetivityY = sensitivity;
    }
}