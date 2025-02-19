using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Collections;
using System.Collections.Generic;
using System;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float maxSpeed = 25f;
    public float turnSpeed = 10000f; 
    private PlayerInput playerInput;

    public float turnFactor = 0.1f;
    public float turnStrength = 2f;
    private float turnInput;
    private Vector2 moveInput;

    public Rigidbody rb;

    private bool isMoving;
    public Transform frontPivot; 

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        // Create a pivot point for front-wheel turning
        GameObject pivot = new GameObject("FrontPivot");
        pivot.transform.SetParent(transform);
        pivot.transform.localPosition = new Vector3(0, 0, 2); 
        frontPivot = pivot.transform;
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

        ApplyTurning();
    }

    void ApplyDrag()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
           rb.MoveRotation(Quaternion.Euler(0, transform.eulerAngles.y + turnInput * turnSpeed, 0));
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

            rb.MoveRotation(Quaternion.Lerp(
                rb.rotation,
                Quaternion.Euler(0, transform.eulerAngles.y + turnInput * turnSpeed, 0),
                Time.fixedDeltaTime * turnFactor
            ));


            Vector3 currentVelocity = rb.linearVelocity;
            Vector3 lateralForce = -transform.right * Vector3.Dot(currentVelocity, transform.right) * turnStrength;
            rb.AddForce(lateralForce, ForceMode.Acceleration);
        }
    }
}
