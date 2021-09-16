using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float JumpHeight;

    private bool AirJumpStatus;
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            AirJumpStatus = true;
            Vector3 Jump = new Vector3(0.0f, JumpHeight, 0.0f);
            rb.AddForce(Jump, ForceMode.Impulse);
        }
        else if(AirJumpStatus == true)
        {
            AirJumpStatus = false;
            Vector3 Jump = new Vector3(0.0f, JumpHeight, 0.0f);
            rb.AddForce(Jump, ForceMode.Impulse);
        }
        else
        {
            //Debug.Log("Unable to jump");
        }
        //Debug.DrawRay(transform.position, Vector3.down, Color.red, 0.3f, true);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * Speed);
    }
}
