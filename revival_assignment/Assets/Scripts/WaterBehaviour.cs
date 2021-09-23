using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private WaterScript WateringCan;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked water");
        if (WateringCan.WaterAmount <= WateringCan.WateringCanCapacity)
        {
            WateringCan.WaterAmount += 5;
        }
    }
}
