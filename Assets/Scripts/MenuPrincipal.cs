using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
  public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CerrarAplicacion()
    {
        Application.Quit();
    }
}
