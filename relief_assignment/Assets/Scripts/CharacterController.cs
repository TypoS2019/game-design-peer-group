using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float RotationSpeed;

    protected Rigidbody rb;
    private float rotation;
    private float movementZ;
    private float DistanceToGround;
    private Quaternion deltaRotation;
    private Vector3 deltaPostition;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("Jumped");
            Vector3 Jump = new Vector3(0.0f, JumpHeight, 0.0f);
            rb.AddForce(Jump, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Unable to jump");
        }
    }

    protected void Move(float movementZ, float rotation)
    {
        deltaPostition = (transform.forward * movementZ) * Speed * Time.deltaTime;
        transform.Translate(deltaPostition, Space.World);

        deltaRotation = Quaternion.Euler(Vector3.up * rotation * Time.deltaTime * RotationSpeed);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
