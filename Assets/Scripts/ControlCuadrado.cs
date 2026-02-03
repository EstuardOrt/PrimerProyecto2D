using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private HolaMundo variableNueva;
    void Start()
    {
        variableNueva = GetComponent<HolaMundo>();
        variableNueva.Saludar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
