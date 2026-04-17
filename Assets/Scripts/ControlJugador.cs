using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ControlJugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Movimiento movimiento;
    private Vector2 entradaControl;
    private LanzaProyectil lanzaProyectiles;
    private bool quiereCorrer = false;
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        lanzaProyectiles = GetComponent<LanzaProyectil>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.Moverse(entradaControl.x, quiereCorrer);
        if (Mathf. Abs(entradaControl.x) > Mathf.Epsilon){
            movimiento. VoltearTransform(entradaControl.x);
            }
        
        movimiento.Escalar(entradaControl.y);
    }

    public void AlMoverse(InputAction.CallbackContext context)
    {
        entradaControl = context.ReadValue<Vector2>();
    }
    public void AlCorrer(InputAction.CallbackContext context)
    {
        if (context.started) quiereCorrer = true;
        if (context.canceled) quiereCorrer = false;
    }

    public void AlSaltar(InputAction.CallbackContext context)
    {
        movimiento.Saltar(context.ReadValueAsButton());
    }

    public void AlLanzar(InputAction.CallbackContext context)
    {
        if (!context.action.triggered){return;}
        lanzaProyectiles.Lanzar();
    }
}
