using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movimiento : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float velocidadEscalar = 1f;
    [Range(0,1)][SerializeField] private float modificadorVelSalto = 0.5f;
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private int saltosExtra = 2;
    [SerializeField] private LayerMask capaDeEscalera;

    private float escalaGravedad = 1f;
    private int saltosRestantes;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        float gravedadEfectiva = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
        //velInicialSalto = Mathf.Sqrt(2f * gravedadEfectiva * alturaSalto);
        saltosRestantes = saltosExtra;
        escalaGravedad = rb.gravityScale;
    }

    public void Saltar(bool debeSaltar)
    {
        if (debeSaltar && saltosRestantes>0)
        {
            float velocidadSalto = Mathf.Sqrt(-2f * rb.gravityScale * Physics2D.gravity.y * alturaSalto);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidadSalto);
            saltosRestantes--;
        }
        if (!debeSaltar && rb.linearVelocity.y > 0)
        {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * modificadorVelSalto);
        }
    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX*velocidadCaminata, rb.linearVelocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

    public void VoltearTransform(float movimientoX){
    transform.localScale = new Vector2(Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private bool EstaEnSuelo(){
    float distanciaDeteccion = 0.1f;
    RaycastHit2D hit = Physics2D.BoxCast(
        boxCollider.bounds.center, 
        boxCollider.bounds.size, 
        0f, 
        Vector2.down, 
        distanciaDeteccion, 
        capaDeSalto
    );
    
    return hit.collider != null;
    }

    public void Escalar(float movimientoY)
    {
        if (!boxCollider.IsTouchingLayers(capaDeEscalera))
        {
         rb.gravityScale = escalaGravedad;
         return;   
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, movimientoY* velocidadEscalar);
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (EstaEnSuelo()){
            saltosRestantes = saltosExtra;
        }
    }
}
