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
    private Weapon weaponSeleccionada;

    public void OpenPanel(Weapon weapon)
    {
        HUDController.Instance.CloseLevelUpPanel();
        weaponSeleccionada = weapon;
        nombreText.text = weapon.WeaponData.nombre;
        textButtons[0].descripcionMejora.text = weapon.DamageText;
        textButtons[1].descripcionMejora.text = weapon.CooldownText;
        textButtons[2].descripcionMejora.text = weapon.SpeedText;
        textButtons[3].descripcionMejora.text = weapon.CantidadText;
    }
    //Click en damage
    public void OnDamageClick()
    {
        if (!weaponSeleccionada.IsMaxDamage())
        {
            weaponSeleccionada.MejorarDamage();
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en cooldown
    public void OnCooldownClick()
    {
        if (!weaponSeleccionada.IsMaxCooldown())
        {
            weaponSeleccionada.MejorarCooldown();
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en speed
    public void OnSpeedClick()
    {
        if (!weaponSeleccionada.IsMaxSpeed())
        {
            weaponSeleccionada.MejorarSpeed();
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en cantidad
    public void OnCantidadClick()
    {
        if (!weaponSeleccionada.IsMaxCantidad())
        {
            weaponSeleccionada.MejorarCantidad();
            HUDController.Instance.MejorasPanelClose();
        }
    }
}