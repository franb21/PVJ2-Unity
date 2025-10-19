using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int armaInicial = 0;

    [SerializeField] private GameObject panelSeleccion;
    [SerializeField] private GameObject marcoTitulo;
    void Start()
    {
        armaInicial = 0;
        panelSeleccion.SetActive(false);
        marcoTitulo.SetActive(true);
    }
    public void Jugar()
    {
        panelSeleccion.SetActive(true);
        marcoTitulo.SetActive(false);
    }

    public void SeleccionarArma(int indice)
    {
        armaInicial = indice; 
        SceneManager.LoadScene("Game");
    }
}