using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPillarBehaviour : MonoBehaviour
{
    [SerializeField] private ActivationPillarBehaviour previousPillar;
    [SerializeField] private GameObject flame;
    
    public delegate void ActivatedIncorrectly();
    public static event ActivatedIncorrectly OnActivatedIncorrectly;
    
    public bool active;

    void Start()
    {
        OnActivatedIncorrectly += Deactivate;
        Deactivate();
    }

    public void Activate()
    {
        if (previousPillar == null)
        {
            flame!.SetActive(true);
            active = true;
        }
        else if (previousPillar.active)
        {
            flame!.SetActive(true);
            active = true;
        }
        else
        {
            OnActivatedIncorrectly!.Invoke();
            flame!.SetActive(false);
            active = false;
        }
    }

    public void Deactivate()
    {        
        flame!.SetActive(false);
        active = false;
    }
}
