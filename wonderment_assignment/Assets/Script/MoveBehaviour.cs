using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform CameraTransform;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float RotateSpeed;
    private Transform transform;
    private Rigidbody rb;
    private Vector2 movement;
    private Vector2 rotation;


    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddTorque(new Vector3(0, rotation.x + transform.rotation.y * Time.deltaTime, 0));
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + (new Vector3(movement.x, 0, movement.y) * Speed * Time.deltaTime));
        CameraTransform.Rotate(new Vector3(-rotation.y * RotateSpeed * Time.deltaTime, 0, 0));
    }

    public void OnMove(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
    }

    public void OnLook(InputValue movementValue)
    {
        rotation = movementValue.Get<Vector2>();
    }

}
