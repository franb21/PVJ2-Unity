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
    public GameObject levelUpPanel;
    public LevelUpButton[] levelUpButtons;
    public GameObject vidaButton;
    public GameObject velocidadButton;
    public GameObject mejorasPanel;
    public MejoraPanel mejorasPanelController;

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
    //Actualiza la vida en el hud
    public void VidaHUD()
    {
        vidaText.text = "VIDA:\n" + (int)JugadorController.Instance.Vida;
    }
    //Actualiza la exp en el hud
    public void ExpHUD()
    {
        expText.text = "\nExperiencia: " + JugadorController.Instance.Experiencia + " / " + JugadorController.Instance.Levels[JugadorController.Instance.LevelActual];
    }
    // Se activa el panel de levelup
    public void OpenLevelUpPanel()
    {
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    // Se desactiva el panel de levelup
    public void CloseLevelUpPanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    // Aumental la vida al dar al button
    public void AumentarVidaJugador()
    {
        JugadorController.Instance.AumentoDeVida();
        Time.timeScale = 1f;
        CloseLevelUpPanel();
    }
    // Aumental la velocidad al dar al button
    public void AumentarVelocidadJugador()
    {
        JugadorController.Instance.AumentoDeVelocidad();
        Time.timeScale = 1f;
        CloseLevelUpPanel();
    }
    // Se activa el panel de mejoras
    public void MejorasPanelOpen(Weapon weapon)
    {
        mejorasPanel.SetActive(true);
        Time.timeScale = 0f;
        mejorasPanelController.OpenPanel(weapon);
    }
    // Se desativa el panel de mejoras
    public void MejorasPanelClose()
    {
        mejorasPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}