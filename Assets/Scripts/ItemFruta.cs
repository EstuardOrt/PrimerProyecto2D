using UnityEngine;

public class ItemFruta : MonoBehaviour
{
    [SerializeField] private int valorFruta = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Puntaje playerPuntaje = collision.GetComponent<Puntaje>();

        if (playerPuntaje != null)
        {
            playerPuntaje.AumentarPuntos(valorFruta);
            Destroy(gameObject); 
        }
    }
}