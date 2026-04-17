using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Salud : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private float saludMax = 3f;
    [SerializeField] private bool destruirAlMorir = true;
    [SerializeField] private bool esJugador = false;
    [SerializeField]private float tiempoEnDestruirse = 0f;
    [SerializeField] private UnityEvent<float> alPerderSalud;
    [SerializeField] private UnityEvent alMorir;
    private float saludActual;
    private Animator animator;
    private bool estaMuerto = false;

    public event Action alActualizarSalud;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
        saludActual = saludMax;
    }

    void Start()
    {
        alActualizarSalud?.Invoke();
    }
    public bool EstaMuerto()
    {
        return estaMuerto;
    }

    public float ObtenerFraccion()
    {
        return saludActual / saludMax;
    }

    public float ObtenerSalud()
    {
        return saludActual;
    }

    public void AjustarSalud(float salud)
    {
        saludActual = salud;
        alActualizarSalud?.Invoke();
    }

    public void PerderSalud(float saludPerdida)
    {
        //animator.ResetTrigger("perderSalud");
        saludActual = Mathf. Max(saludActual - saludPerdida, 0);
        alPerderSalud?. Invoke(saludPerdida);
        alActualizarSalud?.Invoke();
        if (saludActual == 0)
        {
            Morir();
        }
        else
        {
            //animator.SetTrigger("perderSalud");
        }
    }

    public void GanarSalud(float cantidad)
    {
        if (estaMuerto) return;
        
        // Mathf.Min asegura que no sobrepases la salud máxima
        saludActual = Mathf.Min(saludActual + cantidad, saludMax);
        alActualizarSalud?.Invoke();

    }

    private void Morir()
    {
        if (estaMuerto) return;
        alMorir?.Invoke();
        estaMuerto = true;
        
        if (destruirAlMorir)
        {
            Destroy(gameObject, tiempoEnDestruirse);            
        }
        if (esJugador)
        {
            SceneManager.LoadScene("MenuPrincipal");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
