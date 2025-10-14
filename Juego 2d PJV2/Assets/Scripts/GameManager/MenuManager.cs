using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int armaInicial = 0;

    [SerializeField] private GameObject panelSeleccion;
    void Start()
    {
        armaInicial = 0;
        panelSeleccion.SetActive(false);
    }
    public void Jugar()
    {
        panelSeleccion.SetActive(true);
    }

    public void SeleccionarArma(int indice)
    {
        armaInicial = indice; 
        SceneManager.LoadScene("Game");
    }
}