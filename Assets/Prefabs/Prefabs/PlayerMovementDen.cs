using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementDen : MonoBehaviour
{
    public Core Core;
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

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    private float currentStamina;
    public bool staminaDrained = false;
    public bool isSprinting = false;

    public float HeightHurtThreshold;
    private bool landAndHurt = false;

    public float crawlHeight = 1.0f;
    public float crawlSpeed = 1.0f;
    private bool isCrawling = false;

    public float waterSpeedMultiplier;
    public float asphaltSpeedMultiplier;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        currentStamina = stamina;

        readyToJump = true;
    }

    private void FixedUpdate()
    {
        groundArray = Physics.OverlapSphere(groundCheck.transform.position, groundCheck.GetComponent<SphereCollider>().radius * gameObject.transform.localScale.x, whatIsGround);
        grounded = groundArray.Length != 0 && groundArray[0] != GrabbingController.GetHeldObject();
        if (grounded)
            floorTag = groundArray[0].gameObject.tag;
        else
            floorTag = "";
        MyInput();
        SpeedControl(floorTag);
        Crawl();
        HandleFallDamage();

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
            isSprinting = true;
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
        else
            isSprinting = false;
        if (staminaDrained)
        {
            speed *= staminaDrainedMultiplier;
            if (currentStamina > stamina / 2)
                staminaDrained = false;
        }

        if((!Input.GetKey(sprintKey) || staminaDrained) && currentStamina < stamina)
            currentStamina += Time.deltaTime* staminaRechargeSpeed;

        // when to jump (grounded || gameObject.transform.parent!=null)
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
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

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

    private void SpeedControl(string floorTag)
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        switch (floorTag)
        {
            case "Water":
                {
                    //Debug.Log("Slowed down");
                    speed *= waterSpeedMultiplier;
                    break;
                }
            case "Asphalt":
                {
                    //Debug.Log("Sped Up");
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
        return horizontalInput+verticalInput> 0;
    }
    public string GetFloor()
    {
        return floorTag;
    }

    public void HandleFallDamage()
    {
        if(rb.velocity.y > -0.1f && landAndHurt)
        {
            Core.Hurt(2);
            landAndHurt = false;
        }
        landAndHurt = landAndHurt || rb.velocity.y < HeightHurtThreshold;
    }

    public void Crawl()
    {
        if (Input.GetKey(crawlKey))
        {
            speed *= crawlSpeed;
            if (!isCrawling)
            {
                isCrawling = true;
                GrabbingController.gameObject.transform.position = new Vector3(GrabbingController.gameObject.transform.position.x,
                    GrabbingController.gameObject.transform.position.y - 1,
                    GrabbingController.gameObject.transform.position.z);
            }
        }
        else
        {
            if (isCrawling)
            {
                isCrawling = false;
                GrabbingController.gameObject.transform.position = new Vector3(GrabbingController.gameObject.transform.position.x,
                        GrabbingController.gameObject.transform.position.y + 1,
                        GrabbingController.gameObject.transform.position.z);
            }
        }
    }

    void SurfaceSpeed()
    {

    }
}