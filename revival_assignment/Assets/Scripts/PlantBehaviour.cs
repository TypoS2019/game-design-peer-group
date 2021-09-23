using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public bool dead;

    [SerializeField] private Material aliveMaterial;
    [SerializeField] private Material deadMaterial;
    [SerializeField] private GameObject leaves;
    
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Corrupt();
    }

    public void Corrupt()
    {
        dead = true;
        if (leaves != null)
        {
            leaves.SetActive(false);
        }
        meshRenderer.material = deadMaterial;
    }

    public void UnCorrupt()
    {
        dead = false;
        if (leaves != null)
        {
            leaves.SetActive(true);
        }
        meshRenderer.material = aliveMaterial;
    }
}
