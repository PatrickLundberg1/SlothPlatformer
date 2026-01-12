using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset inputActions;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveInput;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip jumpSound;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
        Debug.Log("Player controls enabled.");
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
        Debug.Log("Player controls disabled.");
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        Debug.Log("PlayerMovement Awake called.");
        var playerActionMap = inputActions.FindActionMap("Player");
        // Getting actions from the project-wide Input System

        moveAction = playerActionMap.FindAction("Move");
        jumpAction = playerActionMap.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (jumpAction.WasPressedThisFrame())
        {
            Jump();
            Debug.Log("Jumped!");
        }
    }

    void FixedUpdate()
    {
        // 2D Platformer movement logic, applying horizontal movement
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveInput.x * moveSpeed;
        rb.linearVelocity = velocity;
    }

    private bool IsGrounded()
    {
        // Simple ground check logic (can be improved with raycasting or collision checks)
        return Mathf.Abs(rb.linearVelocity.y) < 0.01f;
    }

    private void Jump()
    {
        if(!IsGrounded()) return;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Level Complete!");
            // Implement level completion logic here

            // Disable player controls
            this.enabled = false;
        }
    }
}
