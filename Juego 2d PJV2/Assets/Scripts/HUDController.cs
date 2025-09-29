using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;
    [Header("Configuracion de HUD")]
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private TextMeshProUGUI expText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void vidaHUD()
    {
        vidaText.text = "VIDA:\n" + (int)JugadorController.Instance.Vida;
    }

    public void expHUD()
    {
        expText.text = "\nExperiencia: " + JugadorController.Instance.Experiencia + " / " + JugadorController.Instance.levels[JugadorController.Instance.LevelActual];
    }

}