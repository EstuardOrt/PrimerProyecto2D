using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimiento : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX*velocidadCaminata, rb.linearVelocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
