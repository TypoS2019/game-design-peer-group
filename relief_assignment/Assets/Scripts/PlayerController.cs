using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private float interactionDistance;
    
    private float rotation;
    private float movementZ;
    

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

    void OnFire()
    {
        ActivationPillarBehaviour[] pillars = FindObjectsOfType<ActivationPillarBehaviour>();
        foreach (var pillar in pillars)
        {
            if (Vector3.Distance(pillar.transform.position, transform.position) <= interactionDistance)
            {
                pillar.Activate();
            }
        }
    }
}
