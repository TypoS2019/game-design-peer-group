using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private KeyBehaviour Key;
    [SerializeField] private float MinDistance;
    [SerializeField] private float OpenSpeed;
    [SerializeField] private float OpenDistance;
    private Transform doorTransform;

    private void Start()
    {
        doorTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Vector3.Distance(doorTransform.position, Key.GetComponent<Transform>().position) <= MinDistance)
        {
            Key.gameObject.SetActive(false);
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        Vector3 oldPosition = doorTransform.position;
        while (true)
        {
            doorTransform.Translate(Vector3.up * OpenSpeed * Time.deltaTime);
            if (doorTransform.position.y > oldPosition.y + OpenDistance)
            {
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator Rotating()
    {
        yield break;
    }
}
