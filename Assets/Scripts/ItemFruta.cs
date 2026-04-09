using UnityEngine;

public class ItemFruta : MonoBehaviour
{
    [SerializeField] private int valorFruta = 1;
    [SerializeField] private AudioClip audioClip; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje playerPuntaje = collision.GetComponent<Puntaje>();

        if (playerPuntaje != null)
        {
         
            playerPuntaje.AumentarPuntos(valorFruta);

            ReproducirSonido();

            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null) sprite.enabled = false;

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