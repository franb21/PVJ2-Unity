using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MejoraPanel : MonoBehaviour
{
    [System.Serializable]
    public class TextStatButton
    {
        public TMP_Text descripcionMejora;
    }
    public TMP_Text nombreText;
    public TextStatButton[] textButtons;
    private Pistola pistolaWeapon;

    public void OpenPanel(Pistola pistola)
    {
        HUDController.Instance.CloseLevelUpPanel();
        pistolaWeapon = pistola;
        nombreText.text = pistola.PistolaData.nombre;
        textButtons[0].descripcionMejora.text = pistola.DamageText;
        textButtons[1].descripcionMejora.text = pistola.CooldownText;
        textButtons[2].descripcionMejora.text = pistola.SpeedText;
        textButtons[3].descripcionMejora.text = pistola.CantidadText;
    }
    //Click en damage
    public void OnDamageClick()
    {
        if (!pistolaWeapon.IsMaxDamage())
        {
            pistolaWeapon.MejorarDamage();
            HUDController.Instance.MejorasPanelClose();
            Debug.Log("mejorao");

        }
        if (pistolaWeapon.IsMaxDamage()){
            Debug.Log("maximoo");
        }
    }
    //Click en cooldown
    public void OnCooldownClick()
    {
        if (!pistolaWeapon.IsMaxCooldown())
        {
            pistolaWeapon.MejorarCooldown();
            HUDController.Instance.MejorasPanelClose();
            Debug.Log("mejorao");

        }
        if (pistolaWeapon.IsMaxCooldown())
        {
            Debug.Log("maximoo");
        }
    }
    //Click en speed
    public void OnSpeedClick()
    {
        if (!pistolaWeapon.IsMaxSpeed())
        {
            pistolaWeapon.MejorarSpeed();
            HUDController.Instance.MejorasPanelClose();
            Debug.Log("mejorao");

        }
        if (pistolaWeapon.IsMaxSpeed())
        {
            Debug.Log("maximoo");
        }
    }
    //Click en cantidad
    public void OnCantidadClick()
    {
        if (!pistolaWeapon.IsMaxCantidad())
        {
            pistolaWeapon.MejorarCantidad();
            HUDController.Instance.MejorasPanelClose();
            Debug.Log("mejorao");

        }
        if (pistolaWeapon.IsMaxCantidad())
        {
            Debug.Log("maximoo");
        }
    }
}