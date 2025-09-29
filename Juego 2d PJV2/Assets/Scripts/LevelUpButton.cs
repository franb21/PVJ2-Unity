using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    public TMP_Text nombreText;
    public TMP_Text descipcionText;
    public Image weaponImagen;
    //Asignar la pistola al button
    public void AsignarButton(Pistola pistola)
    {
        nombreText.text = pistola.PistolaData.nombre;
        descipcionText.text = pistola.PistolaData.descripcion;
        weaponImagen.sprite = pistola.PistolaData.icono;
    }

    public void SelectUpgrade()
    {
        //mejoraPistola se pasa
        // abre panel para mejoras
    }
}
