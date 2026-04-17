using UnityEngine;

public class ItemFruta : MonoBehaviour
{
    [SerializeField] private int valorFruta = 1;
    [SerializeField] private AudioClip audioClip; 
    [SerializeField] private float saludARecuperar = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje playerPuntaje = collision.GetComponent<Puntaje>();
        Salud playerSalud = collision.GetComponent<Salud>();

        if (playerPuntaje != null || playerSalud != null)
        {
            if (playerPuntaje != null) playerPuntaje.AumentarPuntos(valorFruta);
            if (playerSalud != null) playerSalud.GanarSalud(saludARecuperar);

            ReproducirSonido();

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null) sprite.enabled = false;
            
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, audioClip.length);
        }
    }

    private void ReproducirSonido()
    {
        if (audioClip == null) return;

        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}