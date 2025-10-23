using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int armaInicial = 0;

    [SerializeField] private GameObject panelSeleccion;
    [SerializeField] private GameObject marcoTitulo;
    [SerializeField] private AudioSource button;

    void Start()
    {
        armaInicial = 0;
        panelSeleccion.SetActive(false);
        marcoTitulo.SetActive(true);
    }
    public void Jugar()
    {
        button.Play();
        panelSeleccion.SetActive(true);
        marcoTitulo.SetActive(false);
    }

    public void SeleccionarArma(int indice)
    {
        button.Play();
        armaInicial = indice; 
        SceneManager.LoadScene("Game");
    }
}