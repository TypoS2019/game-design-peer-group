using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantBehaviour : MonoBehaviour, IPointerClickHandler
{
    public bool dead;

    [SerializeField] private WaterScript WateringCan;
    [SerializeField] private Material aliveMaterial;
    [SerializeField] private Material deadMaterial;
    [SerializeField] private GameObject leaves;
    
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshRenderer meshRenderer1;

    void Start()
    {
        UnCorrupt();
    }

    public void Corrupt()
    {
        dead = true;
        if (leaves != null)
        {
            leaves.SetActive(false);
        }
        meshRenderer.material = deadMaterial;
        meshRenderer1.material = deadMaterial;
    }
    

    public void UnCorrupt()
    {
        dead = false;
        if (leaves != null)
        {
            leaves.SetActive(true);
        }
        meshRenderer.material = aliveMaterial;
        meshRenderer1.material = aliveMaterial;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked Plant");
        if (WateringCan.WaterAmount >= 5.0f)
        {
            UnCorrupt();
            WateringCan.WaterAmount -= 5;
        }
    }
}
