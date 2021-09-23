using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    
    
    private Vector2 movement;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.MovePosition(transform.position + (new Vector3(movement.x, 0, movement.y) * Speed * Time.deltaTime));
    }

    public void OnMove(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
    }
}