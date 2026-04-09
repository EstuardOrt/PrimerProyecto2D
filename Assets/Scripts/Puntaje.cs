using UnityEngine;
using UnityEngine.Events;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private int puntosActuales = 0;

    
    public UnityEvent<int> onPuntajeCambiado;

    public void AumentarPuntos(int cantidad)
    {
        puntosActuales += cantidad;
        
        
        onPuntajeCambiado?.Invoke(puntosActuales);
    }
}