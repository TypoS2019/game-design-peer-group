using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float RotationSpeed;

    private float rotation;
    private float movementZ;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move(movementZ, rotation);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        rotation = movementVector.x;
        movementZ = movementVector.y;
    }

    void OnJump()
    {
        Jump();
    }
}
