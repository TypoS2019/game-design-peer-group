using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController target;
    [SerializeField] private float minAttackDistance;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float minAttackTime;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(Chasing());
    }

    IEnumerator Chasing()
    {
        while (true)
        {
            Debug.Log("chasing");
            if (target != null)
            {
                RotateTowardsTarget();
                WalkTowardsTarget();
            
                if (Vector3.Distance(transform.position, target.transform.position) <= minAttackDistance)
                {
                    StartCoroutine(Attacking());
                    yield break;
                }
            }
            yield return null;
        }
        yield break;
    }

    IEnumerator Attacking()
    {
        float attackTime = 0;
        while (true)
        {
            Debug.Log("attacking");
            attackTime += Time.deltaTime;
            if (attackTime >= minAttackTime)
            {
                Destroy(target);
            }
            if (target != null)
            {
                if (Vector3.Distance(transform.position, target.transform.position) >= minAttackDistance)
                {
                    StartCoroutine(Chasing());
                    yield break;
                }
            }
            yield return null;
        }
        yield break;
    }
    
    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        targetRotation.Set(0, targetRotation.y, 0, targetRotation.w);
        
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * rotateSpeed));
    }

    private void WalkTowardsTarget()
    {
        rb.MovePosition(transform.position + transform.forward * movementSpeed * Time.deltaTime);
    }
}
