using UnityEngine;
using TMPro;

public class PuntajePantalla : MonoBehaviour
{
    private TextMeshProUGUI textoMesh;
    [SerializeField] private Puntaje scriptPuntajeJugador;

    void Awake()
    {
        textoMesh = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        
        if (scriptPuntajeJugador != null)
        {
            scriptPuntajeJugador.onPuntajeCambiado.AddListener(ActualizarTexto);
        }
    }

    void OnDisable()
    {
        
        if (scriptPuntajeJugador != null)
        {
            scriptPuntajeJugador.onPuntajeCambiado.RemoveListener(ActualizarTexto);
        }
    }

    private void ActualizarTexto(int nuevosPuntos)
    {
        textoMesh.text = "Puntaje: " + nuevosPuntos.ToString();
    }
}