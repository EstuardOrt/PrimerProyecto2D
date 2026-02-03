using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolaMundo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string mensaje;
    void Start()
    {
        //Saludar();
    }

    public void Saludar()
    {
        Debug.Log(mensaje);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
