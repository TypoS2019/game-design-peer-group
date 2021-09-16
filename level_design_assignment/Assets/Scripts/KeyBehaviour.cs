using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private DoorBehaviour DoorBehaviour;

    private Transform trackedTransform;
    private Transform keyTransform;
    
    void Start()
    {
        keyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        keyTransform.position = trackedTransform.position + Vector3.up;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            trackedTransform = other.transform;
        }
    }
}