using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
//k.v



public class PlayerMovement : MonoBehaviour
{
    // älä muuta jo olevia muuttujia
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public float walkSpeed;
    public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [HideInInspector] public TextMeshProUGUI text_speed;


    public static PlayerMovement Instance
    {
        get
        {
            return s_Instance;
        }
    }

    private static PlayerMovement s_Instance;


    void Awake()
    {
        s_Instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        number = sprintSpeed;
    }

    public bool isSprinting = false;

    float stamina = 100f;
    float maxStamina = 100f;

    float number;

    public Slider slider;

    private void Update()
    {
        // spriting system
        if (isSprinting == true)
        {
            if (stamina >= 0)
            {
                stamina -= 70f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (stamina <= maxStamina)
            {
                stamina += 0f * Time.deltaTime;
            }
        }
        else
        {
            if (stamina <= 100)
            {
                stamina += 0f * Time.deltaTime;
            }
        }

        if (stamina <= 0)
        {
            isSprinting = false;
            moveSpeed = walkSpeed;
        }
        else
        {
            sprintSpeed = number;
        }

        slider.value = stamina;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        //if (Input.GetKeyUp(KeyCode.LeftShift))
       // {
        //    isSprinting = false;
       // }

        if (Input.GetKey(KeyCode.LeftShift) & isSprinting == true)
        {
            moveSpeed = sprintSpeed;
        }

        else
        {
            moveSpeed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.P))
        {
            stamina = maxStamina;
        }
        // maa check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

   
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // hyppy
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on maassa
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

       // on ilmassa
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}