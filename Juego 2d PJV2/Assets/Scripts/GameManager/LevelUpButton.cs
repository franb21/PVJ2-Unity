using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    public TMP_Text nombreText;
    public TMP_Text descipcionText;
    public Image weaponImagen;
    private Weapon weaponSeleccionada;
    //Asignar la pistola al button
    public void AsignarButton(Weapon weapon)
    {
        nombreText.text = weapon.WeaponData.nombre;
        descipcionText.text = weapon.WeaponData.descripcion;
        weaponImagen.sprite = weapon.WeaponData.icono;
        weaponSeleccionada = weapon;
    }

    public void MejoraSelec()
    {
        HUDController.Instance.MejorasPanelOpen(weaponSeleccionada);
    }
}
