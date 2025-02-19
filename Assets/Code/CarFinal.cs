using Unity.Mathematics;
using UnityEngine;

public class CarFinal : MonoBehaviour
{
    public Rigidbody sphereRB;
    
    private bool isCarGrounded;
    private float moveInput;
    private float turnInput;

    public float airDampner;
    public float groundDampner;
    public float moveSpeed; 
    public float reverseSpeed; 
    public float turnSpeed;
    public LayerMask ground;
    public float groundCheckDistance = 1.5f;

    void Start()
    {
        sphereRB.transform.parent = null;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance, ground);
        
        if (isCarGrounded)
        {
            moveInput *= moveInput > 0 ? moveSpeed : reverseSpeed;
        }
        else
        {
            moveInput = 0;
            turnInput = 0;
        }

        transform.position = sphereRB.position;
        
        if (isCarGrounded)
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        if (isCarGrounded)
        {
            float newRotation = turnInput * turnSpeed * Time.deltaTime * Mathf.Sign(moveInput);
            transform.Rotate(0, newRotation, 0, Space.World);
        }

        sphereRB.linearDamping = isCarGrounded ? groundDampner : airDampner;
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        
        if (!isCarGrounded)
        {
            sphereRB.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
        }
    } 
}



