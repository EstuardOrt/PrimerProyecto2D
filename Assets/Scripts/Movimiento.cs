using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimiento : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidadCaminata = 4f;
    private float velInicialSalto;
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private float alturaSalto = 4f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        float gravedadEfectiva = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
        velInicialSalto = Mathf.Sqrt(2f * gravedadEfectiva * alturaSalto);
    }

    public void Saltar(bool debeSaltar)
    {
        if(!boxCollider.IsTouchingLayers(capaDeSalto)){return; }
        if (debeSaltar)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
        }
    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX*velocidadCaminata, rb.linearVelocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
