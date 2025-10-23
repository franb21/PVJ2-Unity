using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MejoraPanel : MonoBehaviour
{

    public TMP_Text nombreText;
    public TMP_Text[] textDescripcion;
    private Weapon weaponSeleccionada;

    public void OpenPanel(Weapon weapon)
    {
        weaponSeleccionada = weapon;
        nombreText.text = weapon.WeaponData.nombre;
        textDescripcion[0].text = weapon.DamageText;
        textDescripcion[1].text = weapon.CooldownText;
        textDescripcion[2].text = weapon.AreaText;
        textDescripcion[3].text = weapon.CantidadText;
    }
    //Click en damage
    public void OnDamageClick()
    {
        if (!weaponSeleccionada.IsMaxDamage())
        {
            weaponSeleccionada.MejorarDamage();
            //Desactiva el arma si esta al maximo
            if (weaponSeleccionada.MaxMejoras())
            {
                JugadorController.Instance.WeaponMax.Add(weaponSeleccionada);
                JugadorController.Instance.WeaponActivas.Remove(weaponSeleccionada);
            }
            AudioController.Instance.Play(AudioController.Instance.selectStat);
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en cooldown
    public void OnCooldownClick()
    {
        if (!weaponSeleccionada.IsMaxCooldown())
        {
            weaponSeleccionada.MejorarCooldown();
            if (weaponSeleccionada.MaxMejoras())
            {
                JugadorController.Instance.WeaponMax.Add(weaponSeleccionada);
                JugadorController.Instance.WeaponActivas.Remove(weaponSeleccionada);
            }
            AudioController.Instance.Play(AudioController.Instance.selectStat);
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en speed
    public void OnAreaClick()
    {
        if (!weaponSeleccionada.IsMaxArea())
        {
            weaponSeleccionada.MejorarArea();
            if (weaponSeleccionada.MaxMejoras())
            {
                JugadorController.Instance.WeaponMax.Add(weaponSeleccionada);
                JugadorController.Instance.WeaponActivas.Remove(weaponSeleccionada);
            }
            AudioController.Instance.Play(AudioController.Instance.selectStat);
            HUDController.Instance.MejorasPanelClose();
        }
    }
    //Click en cantidad
    public void OnCantidadClick()
    {
        if (!weaponSeleccionada.IsMaxCantidad())
        {
            weaponSeleccionada.MejorarCantidad();
            if (weaponSeleccionada.MaxMejoras())
            {
                JugadorController.Instance.WeaponMax.Add(weaponSeleccionada);
                JugadorController.Instance.WeaponActivas.Remove(weaponSeleccionada);
            }
            AudioController.Instance.Play(AudioController.Instance.selectStat);
            HUDController.Instance.MejorasPanelClose();
        }
    }
}