using Unity.Mathematics;
using UnityEngine;

public class CarFinal : MonoBehaviour
{
    public Rigidbody sphereRB;

    private bool isCarGrounded;
    private float moveInput;
    private float turnInput;
    private float currentYaw;
    private Vector3 velocity = Vector3.zero;

    public float airDampner;
    public float groundDampner;
    public float moveSpeed;
    public float reverseSpeed;
    public float turnSpeed;
    public LayerMask ground;
    public float groundCheckDistance = 1.5f;
    public float smoothTime = 0.2f;
    public string carLayerName = "Car";

    private Vector3 spherePreviousPosition;

    void Start()
    {
        currentYaw = transform.eulerAngles.y;
        sphereRB.transform.parent = null;
        spherePreviousPosition = sphereRB.position;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        int carLayer = LayerMask.NameToLayer(carLayerName);
        int groundLayerMask = ground.value & ~(1 << carLayer);

        RaycastHit hit;
        isCarGrounded = Physics.Raycast(sphereRB.position, -Vector3.up, out hit, groundCheckDistance, ground);

        if (isCarGrounded)
        {
            moveInput *= moveInput > 0 ? moveSpeed : reverseSpeed;
        }
        else
        {
            moveInput = 0;
            turnInput = 0;
        }


        Vector3 targetPosition = sphereRB.position + new Vector3(0, -0.5f, 0);
        Vector3 directionToTarget = targetPosition - transform.position;


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);


        if (isCarGrounded)
        {
            currentYaw += turnInput * turnSpeed * Time.deltaTime;

            Quaternion yawRotation = Quaternion.Euler(0, currentYaw, 0);

            Quaternion groundAlignment = Quaternion.FromToRotation(Vector3.up, hit.normal);

            Quaternion targetRotation = groundAlignment * yawRotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }


        sphereRB.linearDamping = isCarGrounded ? groundDampner : airDampner;


        spherePreviousPosition = sphereRB.position;
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
