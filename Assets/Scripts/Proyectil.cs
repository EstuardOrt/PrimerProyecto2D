using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Proyectil : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float ataque = 1f;
    [SerializeField] private float velocidad = 5f;

    private Rigidbody2D rb;
    private EquipoEnum equipoEnum;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void AjustarEquipoEnum(EquipoEnum equipoEnum)
    {
        this. equipoEnum = equipoEnum;
    }

    public void AjustarDireccion(Vector2 direccion)
    {
        rb.linearVelocity = direccion.normalized * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.TryGetComponent<Salud>(out Salud saludDelOtro)){return;}
        if (!other. gameObject. TryGetComponent<Equipo>(out Equipo equipoDelOtro)){return;}
        if (equipoDelOtro.EquipoActual == equipoEnum) { return; }
        saludDelOtro.PerderSalud(ataque);
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
