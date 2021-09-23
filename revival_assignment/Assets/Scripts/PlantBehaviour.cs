using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public bool corrupted;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Corrupt()
    {
        corrupted = true;
    }

    public void UnCorrupt()
    {
        corrupted = false;
    }
}
