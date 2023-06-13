using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementDen : MonoBehaviour
{
    float speed;
    public float moveSpeed;

    public int stamina;
    public int staminaRechargeSpeed;
    public float staminaDrainedMultiplier;
    public AudioSource staminaPanting;

    public float speedCoeficient;
    
    public float groundDrag, airDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float sprintMultiplier;
    bool readyToJump;

    public Vector3 velocity;
    public float gravity;

    public GameObject groundCheck;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftControl;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private float currentStamina;
    private bool staminaDrained;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        staminaDrained = false;
        currentStamina = stamina;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        grounded = Physics.CheckSphere(groundCheck.transform.position, groundCheck.GetComponent<SphereCollider>().radius * gameObject.transform.localScale.x, whatIsGround);
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = airDrag;
        MovePlayer();

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        speed = moveSpeed + verticalInput * moveSpeed * speedCoeficient;
        if (Input.GetKey(sprintKey) && verticalInput >= 0.2f && !staminaDrained)
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

        if((!Input.GetKey(sprintKey) || staminaDrained) && currentStamina < stamina)
            currentStamina += Time.deltaTime* staminaRechargeSpeed;

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && (grounded || gameObject.transform.parent!=null))
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            transform.GetChild(4).GetChild(0).GetComponent<Collider>().material.dynamicFriction = 0.03f;
            velocity = Vector3.zero;
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }

        // in air
        else if (!grounded)
        {
            transform.GetChild(4).GetChild(0).GetComponent<Collider>().material.dynamicFriction = 0;
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
            velocity.y += gravity * Time.deltaTime;
            rb.velocity += velocity;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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
}