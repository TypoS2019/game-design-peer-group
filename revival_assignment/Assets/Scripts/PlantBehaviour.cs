using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public bool dead;

    [SerializeField] private Material aliveMaterial;
    [SerializeField] private Material deadMaterial;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Corrupt()
    {
        dead = true;
    }

    public void UnCorrupt()
    {
        dead = false;
    }
}
