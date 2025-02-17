using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float maxSpeed = 25f;
    public float jumpHeight = 2f;
    public float turnSpeed = 10f;
    private PlayerInput playerInput;

    public float turnFactor = 1.2f;
    public float turnStrength = 10f;
    private float turnInput;
    private Vector2 moveInput;

    public Rigidbody rb;

    private bool isMoving;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        turnInput = moveInput.x;

        isMoving = moveInput != Vector2.zero;


        if (isMoving && rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveInput.y * moveSpeed, ForceMode.Acceleration);
        }
        else if (!isMoving)
        {

            ApplyDrag();
        }


        rb.angularVelocity = new Vector3(0, turnInput * turnSpeed, 0);
        
        ApplyTurning();
    }

    void ApplyDrag()
    {

        if (rb.linearVelocity.magnitude > 0.1f)
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, Time.fixedDeltaTime * 5f); // Increase damping factor if needed
        }
        else
        {
            rb.linearVelocity = Vector3.zero; 
        }
    }

    void ApplyTurning()
    {

        if (isMoving)
        {
            Vector3 currentVelocity = rb.linearVelocity;

            Vector3 turnForce = -transform.right * Vector3.Dot(currentVelocity, transform.right) * turnStrength;
            rb.AddForce(turnForce, ForceMode.Acceleration);
        }
    }
}
