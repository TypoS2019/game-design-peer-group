using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScriptableObject : MonoBehaviour
{
    private PlantBehaviour[] plantBehaviours;
    private Transform lightTransform;
    
    [SerializeField] private float maxRotation;
    [SerializeField] private float minRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        lightTransform = GetComponent<Transform>();
        plantBehaviours = GameObject.FindObjectsOfType<PlantBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetRotation = maxRotation - 90;
        float rotationRange = maxRotation;
        float rotationStep = rotationRange / plantBehaviours.Length;

        foreach (var plantBehaviour in plantBehaviours)
        {
            if (!plantBehaviour.dead)
            {
                targetRotation += rotationStep;
            }
        }
        Debug.Log(targetRotation);
        lightTransform.rotation = Quaternion.Slerp(lightTransform.rotation, Quaternion.Euler(targetRotation, 0, 0), 1 * Time.deltaTime);
    }
}
