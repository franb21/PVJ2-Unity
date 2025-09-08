using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController Instance;
    [Header("Configuracion de HUD")]
    [SerializeField] private TextMeshProUGUI vidaText;
    [SerializeField] private TextMeshProUGUI expText;

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
        vidaText.text = "VIDA:\n" + (int)JugadorController.Instance.vida;
    }

    public void expHUD()
    {
        expText.text = "Oleada " + JugadorController.Instance.oleada +
               "\nExperiencia: " + JugadorController.Instance.experiencia +
               " / " + JugadorController.Instance.LevelPlayer;
    }

}