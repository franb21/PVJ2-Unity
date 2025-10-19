using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;

    [Header("Configuracion de HUD")]
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI killsTextWin;
    [SerializeField] private TextMeshProUGUI killsTextGameOver;
    public GameObject estadosJugador;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject levelUpPanel;
    public LevelUpButton[] levelUpButtons;
    public GameObject vidaButton;
    public GameObject velocidadButton;
    public GameObject mejorasPanel;
    public MejoraPanel mejorasPanelController;
    public GameObject bloodEffect;
    private int killsCount;

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
        vidaText.text = "" + (int)JugadorController.Instance.Vida;
    }
    //Actualiza la exp en el hud
    public void ExpHUD()
    {
        expText.text = JugadorController.Instance.Experiencia + " / " + JugadorController.Instance.Levels[JugadorController.Instance.LevelActual];
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
    // Se activa efecto de vida
    public void BloodOpen()
    {
        bloodEffect.SetActive(true);
    }
    // // Se desactiva efecto de vida
    public void BloodClose()
    {
        bloodEffect.SetActive(false);
    }
    // Kills en pantalla
    public void ActualizarKills()
    {
        killsCount++;
        killsText.text = "KILLS:" + killsCount;
        killsTextGameOver.text = killsText.text;
        killsTextWin.text = killsText.text;
    }  
}