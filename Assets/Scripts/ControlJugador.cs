using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ControlJugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Movimiento movimiento;
    private Vector2 entradaControl;
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.Moverse(entradaControl.x);
    }

    public void AlMoverse(InputAction.CallbackContext context)
    {
        entradaControl = context.ReadValue<Vector2>();
    }

    public void AlSaltar(InputAction.CallbackContext context)
    {
        movimiento.Saltar(context.action.triggered);
    }
}
