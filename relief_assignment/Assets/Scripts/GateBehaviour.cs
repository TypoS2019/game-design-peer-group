using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [SerializeField] private ActivationPillarBehaviour ActivationPillarBehaviour;

    [SerializeField] private Transform rightDoor;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform endRotationPoint;
    [SerializeField] private float speed;
    
    void Update()
    {
        if (ActivationPillarBehaviour.active)
        {
            OpenDoor(rightDoor);
            OpenDoor(leftDoor);
        }
    }

    void OpenDoor(Transform door)
    {
        Vector3 targetDirection = (endRotationPoint.position - door.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        door.rotation = Quaternion.RotateTowards(door.rotation, targetRotation , Time.deltaTime * speed);
    }
}
