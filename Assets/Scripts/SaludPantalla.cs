using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class SaludPantalla : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private Salud salud;
    [SerializeField] private Image barraSalud;

    private void OnEnable() {
        salud.alActualizarSalud += ActualizarBarra;
    }

    private void OnDisable() {
        salud.alActualizarSalud -= ActualizarBarra;
    }

    private void ActualizarBarra()
    {
        barraSalud.fillAmount = salud.ObtenerFraccion();
    }
}
