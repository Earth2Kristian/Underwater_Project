using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsScript : MonoBehaviour
{
    private static PlayerControlsScript instance = null;
    public InputAction playerControls;

    // Body Variables
    public Rigidbody rb;
    public CapsuleCollider cc;
    public CharacterController controller;

    // Basic Movement Variables
    private Vector2 movementInput = Vector2.zero;
    private Vector3 velocity;
    private float startingSpeed = 3f;
    public float currentSpeed;

    // Basic Jump Variables
    private bool jumped = false;
    public float jumpHeight = 5f;
    public float jumpLimited = 1f;
    public float gravity = -9.8f;

    public Transform playerBody;

    // Ground Check
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded;

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        currentSpeed = startingSpeed;

        rb.GetComponent<Rigidbody>();
        cc.GetComponent<CapsuleCollider>();
        controller.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // When the player move the left stick left or right
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
        jumped = context.performed;

        if (context.performed && isGrounded)
        {
            // When the player jumps from the ground
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
    }


    void Update()
    {
        // Basic Player Movement
        float moveHorizontal = movementInput.x;
        float moveVertical = movementInput.y;

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        controller.Move(move * currentSpeed * Time.deltaTime);


        // Checks the ground for the player
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            // If the player is on the ground or on a platform
            velocity.y = 0f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    void Awake()
    {
        instance = this;
    }

    public static PlayerControlsScript Instance
    {
        get
        {
            return instance;
        }
    }
}

