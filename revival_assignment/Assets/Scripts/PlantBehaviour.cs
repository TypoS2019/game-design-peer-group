using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantBehaviour : MonoBehaviour, IPointerClickHandler
{
    public bool dead;

    [SerializeField] private Water WateringCan;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("clicked Plant");
        if (WateringCan.WaterAmount >= 5.0f)
        {
            UnCorrupt();
            WateringCan.WaterAmount -= 5;
        }
    }
}
